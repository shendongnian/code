    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Spatial;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    /// <summary>
    /// The <see cref="DbGeography"/> GeoJSON converter
    /// </summary>
    public class DbGeographyGeoJsonConverter : JsonConverter
    {
     /// Well-known-binary values.
     private const int PointWkb = 1;
     private const int LineStringWkb = 2;
     private const int PolygonWkb = 3;
     private const int MultiPointWkb = 4;
     private const int MultiLineStringWkb = 5;
     private const int MultiPolygonWkb = 6;
     private const int GeometryCollectionWkb = 7;
     /// <summary>
     /// Well-known-binary line value.
     /// </summary>
     private static readonly Dictionary<int, string> WkbTypes = 
     new Dictionary<int, string>
     {
      { PointWkb, "Point" },
      { LineStringWkb, "LineString" },
      { PolygonWkb, "Polygon" },
      { MultiPointWkb, "MultiPoint" },
      { MultiLineStringWkb, "MultiLineString" },
      { MultiPolygonWkb, "MultiPolygon" },
      { GeometryCollectionWkb, "GeometryCollection" }
     };
     /// <summary>
     /// The types derived from <see cref="GeoBase"/> accessed by name.
     /// </summary>
     private static readonly Dictionary<string, Type> GeoBases =
     new Dictionary<string, Type>
     {
      { "Point", typeof(Point) },
      { "LineString", typeof(LineString) },
      { "Polygon", typeof(Polygon) },
      { "MultiPoint", typeof(MultiPoint) },
      { "MultiLineString", typeof(MultiLineString) },
      { "MultiPolygon", typeof(MultiPolygon) },
      { "GeometryCollection", typeof(Collection) },
     };
     /// <summary>
     /// Read the GeoJSON type value.
     /// </summary>
     /// <param name="reader">
     /// The reader.
     /// </param>
     /// <returns>
     /// A function that can read the value.
     /// </returns>
     /// <exception cref="ArgumentException">
     /// Unexpected JSON.
     /// </exception>
     /// <remarks>
     /// Leaves the reader positioned where the value should start.
     /// </remarks>
     public static Func<JsonReader, GeoBase> ReadType(JsonReader reader)
     {
      //// TODO: rearchitect to skip unrequired properties and to parse the "crs" property into a coordinate system identifier
      reader.Read();
      if (reader.ValueType != typeof(string))
      {
       throw new ArgumentException(string.Format("Expected a string token for the name of the GeoJSON type, got {0}", reader.ValueType.FullName), "reader");
      }
      if (string.Compare("type", (string)reader.Value, StringComparison.InvariantCultureIgnoreCase) != 0)
      {
       throw new ArgumentException(string.Format("Expected a field named \"type\", got {0}", reader.Value), "reader");
      }
      reader.Read();
      if (reader.ValueType != typeof(string))
      {
       throw new ArgumentException(string.Format("Expected a string token for the type of the GeoJSON type, got {0}", reader.ValueType.FullName), "reader");
      }
      Type geoType;
      if (GeoBases.TryGetValue((string)reader.Value, out geoType))
      {
       reader.Read();
       if (reader.ValueType != typeof(string))
       {
        throw new ArgumentException(string.Format("Expected a string token for the name of the GeoJSON coordinates, got {0}", reader.ValueType.FullName), "reader");
       }
       if (string.Compare(geoType == typeof(Collection) ? "geometries" : "coordinates", (string)reader.Value, StringComparison.InvariantCultureIgnoreCase) != 0)
       {
        throw new ArgumentException(
        string.Format(
        "Expected a field named \"{0}\", got {1}",
        geoType == typeof(Collection) ? "geometries" : "coordinates",
        reader.Value),
        "reader");
       }
       return r =>
       {
        var geo = (GeoBase)Activator.CreateInstance(geoType);
        geo.ParseJson(r);
        return geo;
       };
      }
      throw new ArgumentException(string.Format("Got unsupported GeoJSON object type {0}. Expected one of [{1}]", reader.Value, string.Join(", ", GeoBases.Keys)), "reader");
     }
     /// <inheritdoc/>
     public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
     {
      BinaryReader lebr;
      BinaryReader bebr;
      var geographyValue = value as DbGeography;
      if (geographyValue != null)
      {
       var br = new BinaryReader(new MemoryStream(geographyValue.AsBinary()));
       lebr = BitConverter.IsLittleEndian ? br : new ReverseEndianBinaryReader(br.BaseStream);
       bebr = BitConverter.IsLittleEndian ? new ReverseEndianBinaryReader(br.BaseStream) : br;
      }
      else
      {
       var geometryValue = value as DbGeometry;
       if (geometryValue != null)
       {
        var br = new BinaryReader(new MemoryStream(geometryValue.AsBinary()));
        lebr = BitConverter.IsLittleEndian ? br : new ReverseEndianBinaryReader(br.BaseStream);
        bebr = BitConverter.IsLittleEndian ? new ReverseEndianBinaryReader(br.BaseStream) : br;
       }
       else
       {
        throw new ArgumentException(
        string.Format("Expecting DbGeography or DbGeometry, got {0}", value.GetType().FullName), "value");
       }
      }
      WriteObject(lebr, bebr, writer);
     }
     /// <inheritdoc/>
     public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
     {
      Func<Tuple<byte[], int>, object> returnValue;
      int defaultCoordinateSystemId;
      if (typeof(DbGeography).IsAssignableFrom(objectType))
      {
       returnValue = x => (object)DbGeography.FromBinary(x.Item1, x.Item2);
       defaultCoordinateSystemId = DbGeography.DefaultCoordinateSystemId;
      }
      else if (typeof(DbGeometry).IsAssignableFrom(objectType))
      {
       returnValue = x => (object)DbGeometry.FromBinary(x.Item1, x.Item2);
       defaultCoordinateSystemId = DbGeometry.DefaultCoordinateSystemId;
      }
      else
      {
       throw new ArgumentException(string.Format("Expected a DbGeography or DbGeometry objectType. Got {0}", objectType.FullName), "objectType");
      }
      return returnValue(GetWellKnownBinary(reader, defaultCoordinateSystemId));
     }
     /// <inheritdoc/>
     public override bool CanConvert(Type objectType)
     {
      return objectType == typeof(DbGeography) || objectType == typeof(DbGeometry);
     }
     /// <summary>
     /// Get well known binary from a <see cref="JsonReader"/>.
     /// </summary>
     /// <param name="reader">
     /// The reader.
     /// </param>
     /// <param name="defaultCoordinateSystemId">
     /// The default coordinate system id.
     /// </param>
     /// <returns>
     /// A tuple of the well-known-binary and the coordinate system identifier.
     /// </returns>
     /// <exception cref="ArgumentException">
     /// Unexpected JSON.
     /// </exception>
     private static Tuple<byte[], int> GetWellKnownBinary(JsonReader reader, int defaultCoordinateSystemId)
     {
      var ob = new MemoryStream();
      if (reader.TokenType != JsonToken.StartObject)
      {
       throw new ArgumentException(string.Format("Expected StartObject JSON token, got {0}", reader.TokenType), "reader");
      }
      var geoBase = ReadType(reader)(reader);
      geoBase.WellKnownBinary(ob);
      reader.Read();
      if (reader.TokenType != JsonToken.EndObject)
      {
       throw new ArgumentException(string.Format("Expected EndObject JSON token, got {0}", reader.TokenType), "reader");
      }
      return new Tuple<byte[], int>(ob.ToArray(), defaultCoordinateSystemId);
     }
     /// <summary>
     /// Write a well-known binary object to JSON.
     /// </summary>
     /// <param name="lebr">
     /// The little-endian binary reader.
     /// </param>
     /// <param name="bebr">
     /// The big-endian binary reader.
     /// </param>
     /// <param name="writer">
     /// The writer.
     /// </param>
     /// <exception cref="ArgumentException">
     /// Unexpected well-known binary.
     /// </exception>
     private static void WriteObject(BinaryReader lebr, BinaryReader bebr, JsonWriter writer)
     {
      writer.WriteStartObject();
      writer.WritePropertyName("type");
      var br = lebr.ReadByte() == 0 ? bebr : lebr;
      int gtype = br.ReadInt32();
      string objTypeName;
      if (!WkbTypes.TryGetValue(gtype, out objTypeName))
      {
       throw new ArgumentException(
       string.Format(
       "Unsupported type {0}. Supported types: {1}",
       gtype,
       string.Join(", ", WkbTypes.Select(kv => string.Format("({0}, {1}", kv.Key, kv.Value)))));
      }
      writer.WriteValue(objTypeName);
      if (gtype == GeometryCollectionWkb)
      {
       writer.WritePropertyName("geometries");
       writer.WriteStartArray();
       int count = br.ReadInt32();
       for (int i = 0; i < count; ++i)
       {
        WriteObject(lebr, bebr, writer);
       }
       writer.WriteEndArray();
      }
      else
      {
       writer.WritePropertyName("coordinates");
       writer.WriteStartArray();
       switch (gtype)
       {
       case PointWkb:
        writer.WriteValue(br.ReadDouble());
        writer.WriteValue(br.ReadDouble());
        break;
       case LineStringWkb:
        WriteLine(br, writer);
        break;
       case PolygonWkb:
        WritePolygon(br, writer);
        break;
       case MultiPointWkb:
        int pointCount = br.ReadInt32();
        for (int i = 0; i < pointCount; ++i)
        {
         br = lebr.ReadByte() == 0 ? bebr : lebr;
         gtype = br.ReadInt32();
         if (gtype != PointWkb)
         {
          throw new ArgumentException(
          string.Format("Expected a type of 1, got {0}", gtype),
          "lebr");
         }
         writer.WriteStartArray();
         writer.WriteValue(br.ReadDouble());
         writer.WriteValue(br.ReadDouble());
         writer.WriteEndArray();
        }
        break;
       case MultiLineStringWkb:
        int lineCount = br.ReadInt32();
        for (int i = 0; i < lineCount; ++i)
        {
         br = lebr.ReadByte() == 0 ? bebr : lebr;
         gtype = br.ReadInt32();
         if (gtype != LineStringWkb)
         {
          throw new ArgumentException(
          string.Format("Expected a type of 2, got {0}", gtype),
          "lebr");
         }
         writer.WriteStartArray();
         WriteLine(br, writer);
         writer.WriteEndArray();
        }
        break;
       case MultiPolygonWkb:
        int polygonCount = br.ReadInt32();
        for (int i = 0; i < polygonCount; ++i)
        {
         br = lebr.ReadByte() == 0 ? bebr : lebr;
         gtype = br.ReadInt32();
         if (gtype != PolygonWkb)
         {
          throw new ArgumentException(
          string.Format("Expected a type of 3, got {0}", gtype),
          "lebr");
         }
         writer.WriteStartArray();
         WritePolygon(br, writer);
         writer.WriteEndArray();
        }
        break;
       default:
        throw new ArgumentException(string.Format("Unsupported geo-type {0}", gtype), "lebr");
       }
       writer.WriteEndArray();
      }
      writer.WriteEndObject();
     }
     /// <summary>
     /// Write a JSON polygon from well-known binary.
     /// </summary>
     /// <param name="br">
     ///     Read from this.
     /// </param>
     /// <param name="writer">
     ///     Write to this.
     /// </param>
     private static void WritePolygon(BinaryReader br, JsonWriter writer)
     {
      int ringCount = br.ReadInt32();
      for (int ri = 0; ri < ringCount; ++ri)
      {
       writer.WriteStartArray();
       WriteLine(br, writer);
       writer.WriteEndArray();
      }
     }
     /// <summary>
     /// Write a JSON line from well-known binary.
     /// </summary>
     /// <param name="br">
     ///     Read from this.
     /// </param>
     /// <param name="writer">
     ///     Write to this.
     /// </param>
     private static void WriteLine(BinaryReader br, JsonWriter writer)
     {
      int count = br.ReadInt32() * 2;
      for (int i = 0; i < count; i += 2)
      {
       writer.WriteStartArray();
       writer.WriteValue(br.ReadDouble());
       writer.WriteValue(br.ReadDouble());
       writer.WriteEndArray();
      }
     }
     /// <summary>
     /// A <see cref="BinaryReader"/> that expects byte-reversed numeric values.
     /// </summary>
     public class ReverseEndianBinaryReader : BinaryReader
     {
      /// <summary>
      /// Initializes a new instance of the <see cref="ReverseEndianBinaryReader"/> class.
      /// </summary>
      /// <param name="stream">
      /// The stream.
      /// </param>
      public ReverseEndianBinaryReader(Stream stream)
      : base(stream)
      {
      }
      /// <inheritdoc/>
      public override short ReadInt16()
      {
       return BitConverter.ToInt16(this.ReadBytes(2).Reverse().ToArray(), 0);
      }
      /// <inheritdoc/>
      public override int ReadInt32()
      {
       return BitConverter.ToInt32(this.ReadBytes(4).Reverse().ToArray(), 0);
      }
      /// <inheritdoc/>
      public override long ReadInt64()
      {
       return BitConverter.ToInt64(this.ReadBytes(8).Reverse().ToArray(), 0);
      }
      /// <inheritdoc/>
      public override ushort ReadUInt16()
      {
       return BitConverter.ToUInt16(this.ReadBytes(2).Reverse().ToArray(), 0);
      }
      /// <inheritdoc/>
      public override uint ReadUInt32()
      {
       return BitConverter.ToUInt32(this.ReadBytes(4).Reverse().ToArray(), 0);
      }
      /// <inheritdoc/>
      public override ulong ReadUInt64()
      {
       return BitConverter.ToUInt64(this.ReadBytes(8).Reverse().ToArray(), 0);
      }
      /// <inheritdoc/>
      public override float ReadSingle()
      {
       return BitConverter.ToSingle(this.ReadBytes(4).Reverse().ToArray(), 0);
      }
      /// <inheritdoc/>
      public override double ReadDouble()
      {
       return BitConverter.ToDouble(this.ReadBytes(8).Reverse().ToArray(), 0);
      }
     }
     /// <summary>
     /// Base class for the types that know how to parse JSON and write well-known binary.
     /// </summary>
     public abstract class GeoBase
     {
      /// <summary>
      /// The point well-known bytes descriptor.
      /// </summary>
      protected static readonly byte[] PointWkbs = BitConverter.GetBytes(PointWkb);
      /// <summary>
      /// The line-string well-known bytes descriptor.
      /// </summary>
      protected static readonly byte[] LineStringWkbs = BitConverter.GetBytes(LineStringWkb);
      /// <summary>
      /// The polygon well-known bytes descriptor.
      /// </summary>
      protected static readonly byte[] PolygonWkbs = BitConverter.GetBytes(PolygonWkb);
      /// <summary>
      /// The multi-point well-known bytes descriptor.
      /// </summary>
      protected static readonly byte[] MultiPointWkbs = BitConverter.GetBytes(MultiPointWkb);
      /// <summary>
      /// The multi-line-string well-known bytes descriptor.
      /// </summary>
      protected static readonly byte[] MultiLineStringWkbs = BitConverter.GetBytes(MultiLineStringWkb);
      /// <summary>
      /// The multi-polygon well-known bytes descriptor.
      /// </summary>
      protected static readonly byte[] MultiPolygonWkbs = BitConverter.GetBytes(MultiPolygonWkb);
      /// <summary>
      /// The collection well-known bytes descriptor.
      /// </summary>
      protected static readonly byte[] GeometryCollectionWkbs = BitConverter.GetBytes(GeometryCollectionWkb);
      /// <summary>
      /// Helper function to parse a <see cref="List{T}"/> of <see cref="Position"/>.
      /// </summary>
      /// <param name="reader">
      /// Get JSON from this.
      /// </param>
      /// <returns>
      /// The parsed JSON.
      /// </returns>
      /// <exception cref="ArgumentException">
      /// Unexpected JSON.
      /// </exception>
      public static List<Position> ParseListPosition(JsonReader reader)
      {
       reader.Read();
       var s = JsonSerializer.CreateDefault();
       var x = s.Deserialize<List<List<double>>>(reader);
       if (x.Any(l => l.Count < 2))
       {
        throw new ArgumentException(
        string.Format(
        "Expected all points to have greater than two points, got {0} with zero and {1} with one",
        x.Count(l => l.Count == 0),
        x.Count(l => l.Count == 1)),
        "reader");
       }
       return x.Select(l => new Position { P1 = l[0], P2 = l[1] }).ToList();
      }
      /// <summary>
      /// Helper function to parse a <see cref="List{T}"/> of <see cref="List{T}"/> of <see cref="Position"/>.
      /// </summary>
      /// <param name="reader">
      /// Get JSON from this.
      /// </param>
      /// <returns>
      /// The parsed JSON.
      /// </returns>
      /// <exception cref="ArgumentException">
      /// Unexpected JSON.
      /// </exception>
      public static List<List<Position>> ParseListListPosition(JsonReader reader)
      {
       reader.Read();
       var s = JsonSerializer.CreateDefault();
       var x = s.Deserialize<List<List<List<double>>>>(reader);
       if (x.Any(r => r.Any(l => l.Count < 2)))
       {
        throw new ArgumentException(
        string.Format(
        "Expected all points to have greater than two points, got {0} with zero and {1} with one",
        x.Sum(r => r.Count(l => l.Count == 0)),
        x.Sum(r => r.Count(l => l.Count == 1))),
        "reader");
       }
       return x.Select(r => r.Select(l => new Position { P1 = l[0], P2 = l[1] }).ToList()).ToList();
      }
      /// <summary>
      /// Helper function to parse a <see cref="List{T}"/> of <see cref="List{T}"/> of <see cref="List{T}"/> of <see cref="Position"/>.
      /// </summary>
      /// <param name="reader">
      /// Get JSON from this.
      /// </param>
      /// <returns>
      /// The parsed JSON.
      /// </returns>
      /// <exception cref="ArgumentException">
      /// Unexpected JSON.
      /// </exception>
      public static List<List<List<Position>>> ParseListListListPosition(JsonReader reader)
      {
       reader.Read();
       var s = JsonSerializer.CreateDefault();
       var x = s.Deserialize<List<List<List<List<double>>>>>(reader);
       if (x.Any(p => p.Any(r => r.Any(l => l.Count < 2))))
       {
        throw new ArgumentException(
        string.Format(
        "Expected all points to have greater than two points, got {0} with zero and {1} with one",
        x.Sum(p => p.Sum(r => r.Count(l => l.Count == 0))),
        x.Sum(p => p.Sum(r => r.Count(l => l.Count == 1)))),
        "reader");
       }
       return x.Select(p => p.Select(r => r.Select(l => new Position { P1 = l[0], P2 = l[1] }).ToList()).ToList()).ToList();
      }
      /// <summary>
      /// Write the contents to <paramref name="sout"/> in well-known 
      /// binary format.
      /// </summary>
      /// <param name="sout">
      /// The stream to write the position to.
      /// </param>
      public abstract void WellKnownBinary(Stream sout);
      /// <summary>
      /// Parse JSON into the <see cref="GeoBase"/>-derived type.
      /// </summary>
      /// <param name="reader">
      /// Get JSON from this.
      /// </param>
      public abstract void ParseJson(JsonReader reader);
     }
     public class Position : GeoBase
     {
      public double P1 { get; set; }
      public double P2 { get; set; }
      /// <inheritdoc/>
      public override void WellKnownBinary(Stream sout)
      {
       sout.Write(BitConverter.GetBytes(this.P1), 0, 8);
       sout.Write(BitConverter.GetBytes(this.P2), 0, 8);
      }
      /// <inheritdoc/>
      public override void ParseJson(JsonReader reader)
      {
       reader.Read();
       var s = JsonSerializer.CreateDefault();
       var l = s.Deserialize<List<double>>(reader);
       if (l.Count < 2)
       {
        throw new ArgumentException(string.Format("Expected at least 2 points for a position, got {0}", l.Count), "reader");
       }
       this.P1 = l[0];
       this.P2 = l[1];
      }
     }
     // ReSharper disable RedundantNameQualifier
     public class Point : GeoBase
     {
      public Position Position { get; set; }
      /// <inheritdoc/>
      public override void WellKnownBinary(Stream sout)
      {
       sout.WriteByte(BitConverter.IsLittleEndian ? (byte)1 : (byte)0);
       sout.Write(GeoBase.PointWkbs, 0, 4);
       this.Position.WellKnownBinary(sout);
      }
      /// <inheritdoc/>
      public override void ParseJson(JsonReader reader)
      {
       this.Position = new Position();
       this.Position.ParseJson(reader);
      }
     }
     public class LineString : GeoBase
     {
      public List<Point> Points { get; set; }
      /// <inheritdoc/>
      public override void WellKnownBinary(Stream sout)
      {
       sout.WriteByte(BitConverter.IsLittleEndian ? (byte)1 : (byte)0);
       sout.Write(GeoBase.LineStringWkbs, 0, 4);
       sout.Write(BitConverter.GetBytes(this.Points.Count), 0, 4);
       foreach (var point in this.Points)
       {
        point.Position.WellKnownBinary(sout);
       }
      }
      /// <inheritdoc/>
      public override void ParseJson(JsonReader reader)
      {
       reader.Read();
       var s = JsonSerializer.CreateDefault();
       var x = s.Deserialize<List<List<double>>>(reader);
       if (x.Any(l => l.Count < 2))
       {
        throw new ArgumentException(
        string.Format(
        "Expected all points to have greater than two points, got {0} with zero and {1} with one",
        x.Count(l => l.Count == 0),
        x.Count(l => l.Count == 1)),
        "reader");
       }
       this.Points = x.Select(l => new Point { Position = new Position { P1 = l[0], P2 = l[1] } }).ToList();
      }
     }
     public class Polygon : GeoBase
     {
      public List<List<Position>> Rings { get; set; }
      /// <inheritdoc/>
      public override void WellKnownBinary(Stream sout)
      {
       sout.WriteByte(BitConverter.IsLittleEndian ? (byte)1 : (byte)0);
       sout.Write(GeoBase.PolygonWkbs, 0, 4);
       sout.Write(BitConverter.GetBytes(this.Rings.Count), 0, 4);
       foreach (var ring in this.Rings)
       {
        sout.Write(BitConverter.GetBytes(ring.Count), 0, 4);
        foreach (var position in ring)
        {
         position.WellKnownBinary(sout);
        }
       }
      }
      /// <inheritdoc/>
      public override void ParseJson(JsonReader reader)
      {
       this.Rings = GeoBase.ParseListListPosition(reader);
      }
     }
     public class MultiPoint : GeoBase
     {
      public List<Position> Points { get; set; }
      /// <inheritdoc/>
      public override void WellKnownBinary(Stream sout)
      {
       byte order = BitConverter.IsLittleEndian ? (byte)1 : (byte)0;
       sout.WriteByte(order);
       sout.Write(GeoBase.MultiPointWkbs, 0, 4);
       sout.Write(BitConverter.GetBytes(this.Points.Count), 0, 4);
       foreach (var point in this.Points)
       {
        sout.WriteByte(order);
        sout.Write(GeoBase.PointWkbs, 0, 4); // Point
        point.WellKnownBinary(sout);
       }
      }
      /// <inheritdoc/>
      public override void ParseJson(JsonReader reader)
      {
       this.Points = GeoBase.ParseListPosition(reader);
      }
     }
     public class MultiLineString : GeoBase
     {
      public List<List<Position>> LineStrings { get; set; }
      /// <inheritdoc/>
      public override void WellKnownBinary(Stream sout)
      {
       byte order = BitConverter.IsLittleEndian ? (byte)1 : (byte)0;
       sout.WriteByte(order);
       // ReSharper disable once RedundantNameQualifier
       sout.Write(GeoBase.MultiLineStringWkbs, 0, 4);
       sout.Write(BitConverter.GetBytes(this.LineStrings.Count), 0, 4);
       foreach (var lineString in this.LineStrings)
       {
        sout.WriteByte(order);
        sout.Write(GeoBase.LineStringWkbs, 0, 4);
        sout.Write(BitConverter.GetBytes(lineString.Count), 0, 4);
        foreach (var position in lineString)
        {
         position.WellKnownBinary(sout);
        }
       }
      }
      /// <inheritdoc/>
      public override void ParseJson(JsonReader reader)
      {
       this.LineStrings = GeoBase.ParseListListPosition(reader);
      }
     }
     public class MultiPolygon : GeoBase
     {
      public List<List<List<Position>>> Polygons { get; set; }
      /// <inheritdoc/>
      public override void WellKnownBinary(Stream sout)
      {
       byte order = BitConverter.IsLittleEndian ? (byte)1 : (byte)0;
       sout.WriteByte(order);
       sout.Write(GeoBase.MultiPolygonWkbs, 0, 4);
       sout.Write(BitConverter.GetBytes(this.Polygons.Count), 0, 4);
       foreach (var polygon in this.Polygons)
       {
        sout.WriteByte(order);
        sout.Write(GeoBase.PolygonWkbs, 0, 4);
        sout.Write(BitConverter.GetBytes(polygon.Count), 0, 4);
        foreach (var ring in polygon)
        {
         sout.Write(BitConverter.GetBytes(ring.Count), 0, 4);
         foreach (var position in ring)
         {
          position.WellKnownBinary(sout);
         }
        }
       }
      }
      /// <inheritdoc/>
      public override void ParseJson(JsonReader reader)
      {
       this.Polygons = GeoBase.ParseListListListPosition(reader);
      }
     }
     public class Collection : GeoBase
     {
      public List<GeoBase> Entries { get; set; }
      /// <inheritdoc/>
      public override void WellKnownBinary(Stream o)
      {
       o.WriteByte(BitConverter.IsLittleEndian ? (byte)1 : (byte)0);
       o.Write(GeoBase.GeometryCollectionWkbs, 0, 4);
       o.Write(BitConverter.GetBytes(this.Entries.Count), 0, 4);
       foreach (var entry in this.Entries)
       {
        entry.WellKnownBinary(o);
       }
      }
      /// <inheritdoc/>
      public override void ParseJson(JsonReader reader)
      {
       this.Entries = new List<GeoBase>();
       reader.Read();
       if (reader.TokenType != JsonToken.StartArray)
       {
        throw new ArgumentException(
        string.Format("Expected the start of a geometries array, got {0}", reader.TokenType));
       }
       this.Entries = new List<GeoBase>();
       for (;;)
       {
        reader.Read();
        if (reader.TokenType != JsonToken.StartObject)
        {
         if (reader.TokenType != JsonToken.EndArray)
         {
          throw new ArgumentException(
          string.Format("Expected StartObject or EndArray JSON token, got {0}", reader.TokenType),
          "reader");
         }
         break;
        }
        this.Entries.Add(DbGeographyGeoJsonConverter.ReadType(reader)(reader));
        reader.Read();
        if (reader.TokenType != JsonToken.EndObject)
        {
         throw new ArgumentException(
         string.Format("Expected EndObject JSON token, got {0}", reader.TokenType),
         "reader");
        }
       }
      }
     }
     // ReSharper restore RedundantNameQualifier
    }

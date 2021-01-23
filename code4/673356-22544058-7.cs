	using System;
	using System.Collections.Generic;
	using System.Data.Entity.Spatial;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using AplPed.Common;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	/// <summary>
	/// The <see cref="DbGeography"/> GeoJSON converter
	/// </summary>
	public class DbGeographyGeoJsonConverter : JsonConverter
	{
		/// <summary>
		/// Well-known-binary point value.
		/// </summary>
		private const int PointWkb = 1;
		/// <summary>
		/// Well-known-binary line value.
		/// </summary>
		private const int LineStringWkb = 2;
		/// <summary>
		/// Well-known-binary polygon value.
		/// </summary>
		private const int PolygonWkb = 3;
		/// <summary>
		/// Well-known-binary multi-point value.
		/// </summary>
		private const int MultiPointWkb = 4;
		/// <summary>
		/// Well-known-binary multi-line value.
		/// </summary>
		private const int MultiLineStringWkb = 5;
		/// <summary>
		/// Well-known-binary multi-polygon value.
		/// </summary>
		private const int MultiPolygonWkb = 6;
		/// <summary>
		/// Well-known-binary geometry collection value.
		/// </summary>
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
		/// <param name="jsonObject">
		/// The JSON object.
		/// </param>
		/// <param name="coordinateSystem">
		/// The coordinate System.
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
		public static GeoBase ParseJsonObjectToGeoBase(JObject jsonObject, out int? coordinateSystem)
		{
			var type = jsonObject["type"];
			if (type == null)
			{
				throw new ArgumentException(string.Format("Expected a \"type\" property, found [{0}]", string.Join(", ", jsonObject.Properties().Select(p => p.Name))));
			}
			if (type.Type != JTokenType.String)
			{
				throw new ArgumentException(string.Format("Expected a string token for the type of the GeoJSON type, got {0}", type.Type), "jsonObject");
			}
			Type geoType;
			if (!GeoBases.TryGetValue(type.Value<string>(), out geoType))
			{
				throw new ArgumentException(
				string.Format(
				"Got unsupported GeoJSON object type {0}. Expected one of [{1}]",
				type.Value<string>(),
				string.Join(", ", GeoBases.Keys)),
				"jsonObject");
			}
			var geoObject = geoType == typeof(Collection) ? jsonObject["geometries"] : jsonObject["coordinates"];
			if (geoObject == null)
			{
				throw new ArgumentException(
				string.Format(
				"Expected a field named \"{0}\", found [{1}]",
				geoType == typeof(Collection) ? "geometries" : "coordinates",
				string.Join(", ", jsonObject.Properties().Select(p => p.Name))),
				"jsonObject");
			}
			var crs = jsonObject["crs"];
			coordinateSystem = crs != null ? ParseCrs(crs.Value<JObject>()) : null;
			var geo = (GeoBase)Activator.CreateInstance(geoType);
			geo.ParseJson(geoObject.Value<JArray>());
			return geo;
		}
		/// <inheritdoc/>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			BinaryReader lebr;
			BinaryReader bebr;
			var geographyValue = value as DbGeography;
			int coordinateSystemId;
			if (geographyValue != null)
			{
				var br = new BinaryReader(new MemoryStream(geographyValue.AsBinary()));
				lebr = BitConverter.IsLittleEndian ? br : new ReverseEndianBinaryReader(br.BaseStream);
				bebr = BitConverter.IsLittleEndian ? new ReverseEndianBinaryReader(br.BaseStream) : br;
				coordinateSystemId = geographyValue.CoordinateSystemId;
			}
			else
			{
				var geometryValue = value as DbGeometry;
				if (geometryValue != null)
				{
					var br = new BinaryReader(new MemoryStream(geometryValue.AsBinary()));
					lebr = BitConverter.IsLittleEndian ? br : new ReverseEndianBinaryReader(br.BaseStream);
					bebr = BitConverter.IsLittleEndian ? new ReverseEndianBinaryReader(br.BaseStream) : br;
					coordinateSystemId = geometryValue.CoordinateSystemId;
				}
				else
				{
					throw new ArgumentException(
					string.Format("Expecting DbGeography or DbGeometry, got {0}", value.GetType().CSharpName()), "value");
				}
			}
			var jsonObject = WriteObject(lebr, bebr);
			jsonObject.Add(
			"crs",
			new JObject
			{
				new JProperty("type", "name"),
				new JProperty(
				"properties",
				new JObject { new JProperty("name", string.Format("EPSG:{0}", coordinateSystemId)) })
			});
			writer.WriteRawValue(jsonObject.ToString(Formatting.None));
		}
		/// <inheritdoc/>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			// Load JObject from stream
			JObject jsonObject = JObject.Load(reader);
			// Create target object based on JObject
			object target = CreateDbGeo(jsonObject, objectType);
			// Populate the object properties
			serializer.Populate(jsonObject.CreateReader(), target);
			return target;
		}
		/// <inheritdoc/>
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(DbGeography) || objectType == typeof(DbGeometry);
		}
		/// <summary>
		/// Parse the coordinate system object and return it's value.
		/// </summary>
		/// <param name="jsonObject">
		/// The JSON object.
		/// </param>
		/// <returns>
		/// The coordinate system value; null if couldn't parse it (only a couple EPSG-style values).
		/// </returns>
		private static int? ParseCrs(JObject jsonObject)
		{
			var properties = jsonObject["properties"];
			if (properties != null && properties.Type == JTokenType.Object)
			{
				var p = properties.Value<JObject>();
				var name = p["name"];
				if (name != null)
				{
					var s = name.Value<string>();
					if (!string.IsNullOrWhiteSpace(s))
					{
						var m = Regex.Match(
						s,
						@"^\s*(urn\s*:\s*ogc\s*:\s*def\s*:crs\s*:EPSG\s*:\s*[\d.]*\s*:|EPSG\s*:)\s*(?<value>\d+)\s*$",
						RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
						if (m.Success)
						{
							return int.Parse(m.Groups["value"].Value);
						}
					}
				}
			}
			return null;
		}
		/// <summary>
		/// Get well known binary from a <see cref="JsonReader"/>.
		/// </summary>
		/// <param name="jsonObject">
		/// The JSON object.
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
		private static Tuple<byte[], int> GetWellKnownBinary(JObject jsonObject, int defaultCoordinateSystemId)
		{
			var ob = new MemoryStream();
			int? coordinateSystemId;
			var geoBase = ParseJsonObjectToGeoBase(jsonObject, out coordinateSystemId);
			geoBase.WellKnownBinary(ob);
			return new Tuple<byte[], int>(ob.ToArray(), coordinateSystemId.HasValue ? coordinateSystemId.Value : defaultCoordinateSystemId);
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
		/// <exception cref="ArgumentException">
		/// Unexpected well-known binary.
		/// </exception>
		/// <returns>
		/// The <see cref="JObject"/> for the given binary data.
		/// </returns>
		private static JObject WriteObject(BinaryReader lebr, BinaryReader bebr)
		{
			var jsonObject = new JObject();
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
			jsonObject.Add("type", objTypeName);
			if (gtype == GeometryCollectionWkb)
			{
				var array = new JArray();
				int count = br.ReadInt32();
				for (int i = 0; i < count; ++i)
				{
					array.Add(WriteObject(lebr, bebr));
				}
				jsonObject.Add("geometries", array);
			}
			else
			{
				var array = new JArray();
				switch (gtype)
				{
				case PointWkb:
					array.Add(br.ReadDouble());
					array.Add(br.ReadDouble());
					break;
				case LineStringWkb:
					foreach (var a in WriteLine(br))
					{
						array.Add(a);
					}
					break;
				case PolygonWkb:
					foreach (var a in WritePolygon(br))
					{
						array.Add(a);
					}
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
						array.Add(new JArray { br.ReadDouble(), br.ReadDouble() });
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
						var lineArray = new JArray();
						foreach (var a in WriteLine(br))
						{
							lineArray.Add(a);
						}
						array.Add(lineArray);
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
						var polygonArray = new JArray();
						foreach (var a in WritePolygon(br))
						{
							polygonArray.Add(a);
						}
						array.Add(polygonArray);
					}
					break;
				default:
					throw new ArgumentException(string.Format("Unsupported geo-type {0}", gtype), "lebr");
				}
				jsonObject.Add("coordinates", array);
			}
			return jsonObject;
		}
		/// <summary>
		/// Write a JSON polygon from well-known binary.
		/// </summary>
		/// <param name="br">
		/// Read from this.
		/// </param>
		/// <returns>
		/// The <see cref="JArray"/> enumerable for the polygon.
		/// </returns>
		private static IEnumerable<JArray> WritePolygon(BinaryReader br)
		{
			var ret = new List<JArray>();
			int ringCount = br.ReadInt32();
			for (int ri = 0; ri < ringCount; ++ri)
			{
				var array = new JArray();
				foreach (var a in WriteLine(br))
				{
					array.Add(a);
				}
				ret.Add(array);
			}
			return ret;
		}
		/// <summary>
		/// Write a JSON line from well-known binary.
		/// </summary>
		/// <param name="br">
		/// Read from this.
		/// </param>
		/// <returns>
		/// The <see cref="JArray"/> enumerable for the line.
		/// </returns>
		private static IEnumerable<JArray> WriteLine(BinaryReader br)
		{
			var ret = new List<JArray>();
			int count = br.ReadInt32() * 2;
			for (int i = 0; i < count; i += 2)
			{
				var array = new JArray { br.ReadDouble(), br.ReadDouble() };
				ret.Add(array);
			}
			return ret;
		}
		/// <summary>
		/// Create a <see cref="DbGeography"/> or <see cref="DbGeometry"/> from <paramref name="jsonObject"/>.
		/// </summary>
		/// <param name="jsonObject">
		/// The JSON object.
		/// </param>
		/// <param name="objectType">
		/// The object type.
		/// </param>
		/// <returns>
		/// The <see cref="DbGeography"/> or <see cref="DbGeometry"/> 
		/// </returns>
		/// <exception cref="ArgumentException">
		/// <paramref name="objectType"/> is not a <see cref="DbGeography"/> or <see cref="DbGeometry"/>.
		/// </exception>
		private static object CreateDbGeo(JObject jsonObject, Type objectType)
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
				throw new ArgumentException(string.Format("Expected a DbGeography or DbGeometry objectType. Got {0}", objectType.CSharpName()), "objectType");
			}
			return jsonObject.Type == JTokenType.Null || jsonObject.Type == JTokenType.None ? null : returnValue(GetWellKnownBinary(jsonObject, defaultCoordinateSystemId));
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
			/// <param name="array">
			/// Get JSON from this.
			/// </param>
			/// <returns>
			/// The parsed JSON.
			/// </returns>
			/// <exception cref="ArgumentException">
			/// Unexpected JSON.
			/// </exception>
			public static List<Position> ParseListPosition(JArray array)
			{
				if (array.Cast<JArray>().Any(l => l.Count < 2))
				{
					throw new ArgumentException(
					string.Format(
					"Expected all points to have greater than two points, got {0} with zero and {1} with one",
					array.Cast<JArray>().Count(l => l.Count == 0),
					array.Cast<JArray>().Count(l => l.Count == 1)),
					"array");
				}
				return array.Select(l => new Position { P1 = (double)l[0], P2 = (double)l[1] }).ToList();
			}
			/// <summary>
			/// Helper function to parse a <see cref="List{T}"/> of <see cref="List{T}"/> of <see cref="Position"/>.
			/// </summary>
			/// <param name="array">
			/// Get JSON from this.
			/// </param>
			/// <returns>
			/// The parsed JSON.
			/// </returns>
			/// <exception cref="ArgumentException">
			/// Unexpected JSON.
			/// </exception>
			public static List<List<Position>> ParseListListPosition(JArray array)
			{
				if (array.Cast<JArray>().Any(r => r.Cast<JArray>().Any(l => l.Count < 2)))
				{
					throw new ArgumentException(
					string.Format(
					"Expected all points to have greater than two points, got {0} with zero and {1} with one",
					array.Cast<JArray>().Sum(r => r.Cast<JArray>().Count(l => l.Count == 0)),
					array.Cast<JArray>().Sum(r => r.Cast<JArray>().Count(l => l.Count == 1))),
					"array");
				}
				return array.Select(r => r.Select(l => new Position { P1 = (double)l[0], P2 = (double)l[1] }).ToList()).ToList();
			}
			/// <summary>
			/// Helper function to parse a <see cref="List{T}"/> of <see cref="List{T}"/> of <see cref="List{T}"/> of <see cref="Position"/>.
			/// </summary>
			/// <param name="array">
			/// Get JSON from this.
			/// </param>
			/// <returns>
			/// The parsed JSON.
			/// </returns>
			/// <exception cref="ArgumentException">
			/// Unexpected JSON.
			/// </exception>
			public static List<List<List<Position>>> ParseListListListPosition(JArray array)
			{
				if (array.Cast<JArray>().Any(p => p.Cast<JArray>().Any(r => r.Cast<JArray>().Any(l => l.Count < 2))))
				{
					throw new ArgumentException(
					string.Format(
					"Expected all points to have greater than two points, got {0} with zero and {1} with one",
					array.Cast<JArray>().Sum(p => p.Cast<JArray>().Sum(r => r.Cast<JArray>().Count(l => l.Count == 0))),
					array.Cast<JArray>().Sum(p => p.Cast<JArray>().Sum(r => r.Cast<JArray>().Count(l => l.Count == 1)))),
					"array");
				}
				return array.Select(p => p.Select(r => r.Select(l => new Position { P1 = (double)l[0], P2 = (double)l[1] }).ToList()).ToList()).ToList();
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
			/// <param name="array">
			/// Get JSON from this.
			/// </param>
			public abstract void ParseJson(JArray array);
		}
		/// <summary>
		/// The position.
		/// </summary>
		public class Position : GeoBase
		{
			/// <summary>
			/// Gets or sets the first value of the position.
			/// </summary>
			public double P1 { get; set; }
			/// <summary>
			/// Gets or sets the second value of the position.
			/// </summary>
			public double P2 { get; set; }
			/// <inheritdoc/>
			public override void WellKnownBinary(Stream sout)
			{
				sout.Write(BitConverter.GetBytes(this.P1), 0, 8);
				sout.Write(BitConverter.GetBytes(this.P2), 0, 8);
			}
			/// <inheritdoc/>
			public override void ParseJson(JArray array)
			{
				if (array.Count < 2)
				{
					throw new ArgumentException(string.Format("Expected at least 2 points for a position, got {0}", array.Count), "array");
				}
				this.P1 = (double)array[0];
				this.P2 = (double)array[1];
			}
		}
		// ReSharper disable RedundantNameQualifier
		/// <summary>
		/// The point.
		/// </summary>
		public class Point : GeoBase
		{
			/// <summary>
			/// Gets or sets the position.
			/// </summary>
			public Position Position { get; set; }
			/// <inheritdoc/>
			public override void WellKnownBinary(Stream sout)
			{
				sout.WriteByte(BitConverter.IsLittleEndian ? (byte)1 : (byte)0);
				sout.Write(GeoBase.PointWkbs, 0, 4);
				this.Position.WellKnownBinary(sout);
			}
			/// <inheritdoc/>
			public override void ParseJson(JArray array)
			{
				this.Position = new Position();
				this.Position.ParseJson(array);
			}
		}
		/// <summary>
		/// The line string.
		/// </summary>
		public class LineString : GeoBase
		{
			/// <summary>
			/// Gets or sets the points.
			/// </summary>
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
			public override void ParseJson(JArray array)
			{
				if (array.Cast<JArray>().Any(l => l.Count < 2))
				{
					throw new ArgumentException(
					string.Format(
					"Expected all points to have greater than two points, got {0} with zero and {1} with one",
					array.Cast<JArray>().Count(l => l.Count == 0),
					array.Cast<JArray>().Count(l => l.Count == 1)),
					"array");
				}
				this.Points = array.Cast<JArray>().Select(l => new Point { Position = new Position { P1 = (double)l[0], P2 = (double)l[1] } }).ToList();
			}
		}
		/// <summary>
		/// The polygon.
		/// </summary>
		public class Polygon : GeoBase
		{
			/// <summary>
			/// Gets or sets the rings.
			/// </summary>
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
			public override void ParseJson(JArray array)
			{
				this.Rings = GeoBase.ParseListListPosition(array);
			}
		}
		/// <summary>
		/// The multi-point.
		/// </summary>
		public class MultiPoint : GeoBase
		{
			/// <summary>
			/// Gets or sets the points.
			/// </summary>
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
			public override void ParseJson(JArray array)
			{
				this.Points = GeoBase.ParseListPosition(array);
			}
		}
		/// <summary>
		/// The multi-line.
		/// </summary>
		public class MultiLineString : GeoBase
		{
			/// <summary>
			/// Gets or sets the line strings.
			/// </summary>
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
			public override void ParseJson(JArray array)
			{
				this.LineStrings = GeoBase.ParseListListPosition(array);
			}
		}
		/// <summary>
		/// The multi-polygon.
		/// </summary>
		public class MultiPolygon : GeoBase
		{
			/// <summary>
			/// Gets or sets the polygons.
			/// </summary>
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
			public override void ParseJson(JArray array)
			{
				this.Polygons = GeoBase.ParseListListListPosition(array);
			}
		}
		/// <summary>
		/// The <see cref="GeoBase"/> collection.
		/// </summary>
		public class Collection : GeoBase
		{
			/// <summary>
			/// Gets or sets the entries.
			/// </summary>
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
			public override void ParseJson(JArray array)
			{
				this.Entries = new List<GeoBase>();
				foreach (var elem in array)
				{
					if (elem.Type != JTokenType.Object)
					{
						throw new ArgumentException(
						string.Format("Expected object elements of the collection array, got {0}", elem.Type),
						"array");
					}
					int? dummyCoordinateSystem;
					this.Entries.Add(DbGeographyGeoJsonConverter.ParseJsonObjectToGeoBase((JObject)elem, out dummyCoordinateSystem));
				}
			}
		}
		// ReSharper restore RedundantNameQualifier
	}

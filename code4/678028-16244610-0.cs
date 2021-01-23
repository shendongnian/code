    internal abstract class AbstractParser {
      protected TextReader              Reader    { get; set; }
      // etc.
    }
    internal abstract class MapParser : AbstractParser, IParser<IMapDefinition> {
      public abstract IMapDefinition Parse();
      protected internal MapParser(TextReader reader) : this() { 
        Reader = reader;
      }
      public IMapDefinition Parse(Func<MapHeader, string[], int[][],
        HexsideData[,], List<IHpsPlaceName>, int, IMapDefinition> factory
      ) {
        var header     = ParseMapHeader(1);
        var terrain    = ParseTerrain(header.Size);
        var elevations = ParseElevation(header.Size);
        var feature    = ParseFeatures( header.Size);
        var placeNames = ParsePlaceNames();
        return factory(header, terrain, elevations, feature, placeNames, MaxElevationLevel);
      }
      // etc.
    }
    internal class MapV1Parser : MapParser {
      internal MapV1Parser(TextReader reader) : base(reader) {}
      public override IMapDefinition Parse() {
        return base.Parse((h,t,e,f,p,xe) => (new MapDefinitionV1(h,t,e,f,p,xe)));
      }
    }
    internal class MapV2Parser : MapParser {
      private readonly Regex regexHeaderLine3;
      internal MapV2Parser(TextReader reader) : base(reader) {
        regexHeaderLine3  = new Regex(@"^([-]?[0-9]+) ([0-9]+) ([0-9]+) ([0-9]+) ([0-1])$",
                                      RegexOptions.None);
      }
      public override IMapDefinition Parse() {
        return base.Parse((h,t,e,f,p,xe) => (new MapDefinitionV2(h,t,e,f,p,xe)));
      }
    }

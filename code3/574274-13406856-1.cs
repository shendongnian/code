    // here's the custom attribute. Ok, should probably be sealed and bla bla bla.
    public class MapToAttribute : Attribute {
      readonly string _fieldName;
  
      public MapToAttribute(string fieldName) {
        _fieldName = fieldName;
      }
    }
    // here's your model
    public class SomeModel {
      [MapTo("TaskSequence")]
      public int TaskSequence { get; set; }
    }
    // here's how you figure out which property have the MapTo attribute
    from p in typeof(SomeModel).GetProperties() where p.IsDefined(typeof(MapToAttribute))

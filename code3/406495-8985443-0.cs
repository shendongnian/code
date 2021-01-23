    public class MyResourceCustom : Attribute {
      public MyResourceCustomDescriptor Descriptor { get; private set; }
      public MyResourceCustom(MyResourceCustomDescriptor descriptor)
      : base() {
        Descriptor = descriptor;
      }
    public class MyResourceCustomDescriptor {
      public string          Description    { get; private set; }
      public bool            DefaultValue   { get; private set; }
      public ParameterGroups ParameterGroup { get; private set; }
      public MyResourceCustomDescriptor(string path) {
        // read from path
      }
    }
    public class MyAdvancedResouceCustomDescriptor : MyResourceCustomDescriptor {
      public string DisplayName { get; private set; }
      // etc...
    }

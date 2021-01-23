    public class DragAndDropData : IEquatable<DragAndDropData> {
      public string Name { get; set; }
      public Box(string n)
      {
        this.Name = n;
      }
      ...
      public bool Equals(DragAndDropData other) {
        return (this.Name == other.Name);
      }
    }

    public interface IShape{
      double Area {get;}
      double Perimeter { get; } //Prefer Perimeter over circumference as more applicable to other shapes
      int Sides { get; }
      HoleType ShapeType { get; }
    }

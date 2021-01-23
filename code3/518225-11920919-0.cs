    public class Point
    {
        public virtual Double X {get {return this.x;} set{this.x = value;}}
        public virtual Double Y {...}
        public virtual Double Z {...}
        public Point Clone() {
           return this.MemberwiseClone();
        }
    }
    Point point = cube.Center.Clone();
    point.X += 10.0 // cube1 will NOT move here

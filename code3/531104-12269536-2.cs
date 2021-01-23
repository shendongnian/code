    public class Rectangle {
        ....
        public bool Overlap(Rectangle other)
        {
            return !(this.MinX >= other.MaxX || this.MaxX <= other.MinX ||
                     this.MinY >= other.MaxY || this.MaxY <= other.MinY);
        }
    }

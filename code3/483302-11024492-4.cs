    public class Vector2D : Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
    
        protected override Vector Add(Vector otherVector)
        {
            Vector2D otherVector2D = otherVector as Vector2D;
            if (otherVector2D != null)
                return new Vector2D() { X = this.X + otherVector2D.X, Y = this.Y + otherVector2D.Y };
    
            Vector3D otherVector3D = otherVector as Vector3D;
            if (otherVector3D != null)
                return new Vector3D() { X = this.X + otherVector3D.X, Y = this.Y + otherVector3D.Y, Z = otherVector3D.Z };
    
            //handle other cases
        }
    }
    
    
    public class Vector3D : Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    
        protected override Vector Add(Vector otherVector)
        {
            Vector2D otherVector2D = otherVector as Vector2D;
            if (otherVector2D != null)
                return new Vector3D() { X = this.X + otherVector2D.X, Y = this.Y + otherVector2D.Y, Z = this.Z };
    
            Vector3D otherVector3D = otherVector as Vector3D;
            if (otherVector3D != null)
                return new Vector3D() { X = this.X + otherVector3D.X, Y = this.Y + otherVector3D.Y, Z = this.Z + otherVector3D.Z };
    
            //handle other cases
        }
    }

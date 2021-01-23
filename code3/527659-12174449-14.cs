    public class ExtendedVector2 {
        //...
        private Vector2 _vector2;  
        //mask X and Y values of Vector2 structure 
        public float X{
            set{ _vector2.X = value; }
            get{ return _vector2.X; }
        }
        public float Y{
            set{ _vector2.Y = value; }
            get{ return _vector2.Y; }
        } 
        //example to mask a method of Vector2 structure 
        public static float Dot(ExtendedVector2 value1, ExtendedVector2 value2){
            return Vector.Dot(new Vector2(value1.X, value1.Y), new Vector2(value2.X, value2.Y));
        }
    }

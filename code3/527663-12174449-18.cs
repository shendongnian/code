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
            return Vector.Dot(value1, value2);
        }
       
        //override the cast to Vector2
        public static implicit operator Vector2(ExtendedVector2 value) //I'd make it implicit because I'd think to it like an upcast
        {
            return new Vector2(value.X, value.Y);
        }
    }

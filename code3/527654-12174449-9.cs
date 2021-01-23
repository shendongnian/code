    public class ExtendedVector2 {
        public Vector2 Vector{
            get;
            private set;
        }
        
        public ExtendedVector2(float value){
            Vector = new Vector2(value);
        }   
        
        public ExtendedVector2(float x, float y){
            Vector = new Vector2(x, y);
        }
    }

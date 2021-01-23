    public class ExtendedVector2 {
        private Vector2 _vector2;  
        public float X{
             set{                  
                 if(_vector2.X != value){
                   float oldValue = _vector2.X;
                   _vector2.X = value; 
                   
                   OnMemberValueChanged(new MemberChangedEventArgs(oldvalue, value);
                 }
             }
             get{ return _vector2.X; }
        }
        public float Y{
             set{ 
                 if(_vector2.Y != value){
                   float oldValue = _vector2.Y;
                   _vector2.Y = value; 
                   
                   OnMemberValueChanged(new MemberChangedEventArgs(oldvalue, value);
                 }
             }
             get{ return _vector2.Y; }
        }        
        
        public event EventHandler<MemberChangedEventArgs> MemberChanged;
        public ExtendedVector2(float value){
            Vector = new Vector2(value);
        }   
        
        public ExtendedVector2(float x, float y){
            Vector = new Vector2(x, y);
        }
        private virtual void OnMemberValueChanged(MemberChangedEventArgs e){
            if(MemberChanged != null)
               MemberChanged(this, e);
        }
        
        //... 
        //here mask the Vector2 structure with the previously solution
    }

    public class ExtendedVector2 {
        private Vector2 _vector2;  
        public float X{
             set{                  
                 if(_vector2.X != value)           
                   OnMemberXChanged(new MemberChangedEventArgs(_vector2.X, value));
                 _vector2.X = value;   
             }
             get{ return _vector2.X; }
        }
        public float Y{
             set{ 
                 if(_vector2.Y != value)
                   OnMemberYChanged(new MemberChangedEventArgs(_vector2.Y, value));
                 _vector2.Y = value;                    
             }
             get{ return _vector2.Y; }
        }        
        
        public event EventHandler<MemberChangedEventArgs> MemberXChanged;
        public event EventHandler<MemberChangedEventArgs> MemberYChanged;
        public ExtendedVector2(float value){
            Vector = new Vector2(value);
        }   
        
        public ExtendedVector2(float x, float y){
            Vector = new Vector2(x, y);
        }
        private virtual void OnMemberXChanged(MemberChangedEventArgs e){
            if(MemberXChanged != null)
               MemberXChanged(this, e);
        }
        private virtual void OnMemberYChanged(MemberChangedEventArgs e){
            if(MemberYChanged != null)
               MemberYChanged(this, e);
        }
        //... 
        //here mask the Vector2 structure using the previous solution
    }

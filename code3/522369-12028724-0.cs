    class A
    {
        Vector2 _position;
        Vector2 Position 
        { 
            get { return _position; } 
            set { _position = value; }
        }
    
        public void Foo()
        {
            _position.X = 10.0f;  
        }
    }

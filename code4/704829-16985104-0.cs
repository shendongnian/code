    class Square : Rectangle
    {    
        public float Side{get;set;}
    
        public override float Height { get{return Side;}; set{Side =value;} }
        public override float Width {get{return Side;}; set{Side =value;} }
    
        public Square() : base() { }
    
        public Square(float side)
        {
            this.Side = side;
        }
    }

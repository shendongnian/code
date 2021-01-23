    public class Content 
    { 
        public Content() 
        { 
            Item = new ExtendedLabel(); 
            Value = new ExtendedLabel(); 
        } 
     
        private ExtendedLabel internal_Item = new ExtendedLabel(); 
        private ExtendedLabel internal_Value = new ExtendedLabel(); 
    
        public string Item
        { 
            get{return internal_Item.Text;}
            set{internal_Item.Text = value;}
    
        }
        public string Value
        { 
            get{return internal_Value.Text;}
            set{internal_Value.Text = value;}
        }
    } 

    class MyEntryElement : EntryElement 
    {
        UITextField field; // Class-level variable
        protected override UITextField CreateTextField(RectangleF frame)
        {
            field = base.CreateTextField(frame);
    
            //How do I expose this?
            //field.ShouldChangeCharacters
    
            return field;
        }
    
        public UITextField Field {
            get { return field; }
        }
    
    }

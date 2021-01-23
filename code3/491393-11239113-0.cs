    class Foo
    {
        public string Value { get; set; }
        
        public Foo(Value value)
        {
    
        }
    
        public void HandleClick(object sender, EventArgs e)
        {
            ((Control)sender).Text = Value;
        }
    } 
   

    public class Record
    {
        CustomPanel _panel;
        public CustomPanel panel
        {
             get { return _panel; }
             set { _panel = value; _panel.parent = this; }
        }
        
        public void recordFunc(){}
    }
    
    public class CustomPanel : Panel
    {
        public Record parent { get; set; }
    
        public void myFunc(object sender, EventArgs e)
        {
            parent.recordFunc();
        }
    }

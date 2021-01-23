    public class XmlButton : XmlControl
    {
        public string Label { get; set; } 
        
        public override Type ControlType(){ return typeof(GUIButton); }
    }

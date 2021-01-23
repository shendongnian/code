    public abstract class ParameterBase 
    { 
        public string ParameterName { get; private set; }
        public bool IsRequired { get; private set; }
        public int ParameterId { get; private set; }
     
        public virtual void SetProperties(string xml) 
        { 
            ParameterName = XmlParser.GetParameterName(xml); 
            IsRequired = XmlParser.GetIsRequired(xml); 
            ParameterId = XmlParser.GetParameterId(xml); 
        } 
    } 
     
    public class Parameter1 : ParameterBase 
    { 
        public string Value { get; private set; }
     
		public override void SetProperties(string xml)
		{
			base.SetProperties(xml);
			Value = XmlParser.GetValue(xml);
		}
    } 

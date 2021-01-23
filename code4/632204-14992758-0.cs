    [Serializable]
    [XmlRoot("oneshot")]
    public class OneShot 
    {
    	[XmlElement("form_namespace", Namespace="http://mobileforms.foo.com/xforms")]
    	public string FormNamespace {get; set;}
    	[XmlElement("Days")]
    	public int Days {get; set;}
    	[XmlElement("Leave_Type")]
    	public string LeaveType {get; set;}

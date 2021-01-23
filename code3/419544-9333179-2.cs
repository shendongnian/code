    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "ExecutionHistory", Namespace = "", IsNullable = false)]
    public class ExecutionHistory
    {
       public ExecutionHistory()
       {
          this.CaptureDetails = new CaptureDetails();
          this.DeployDetails = new DeployDetails();
       }
    
       [XmlElementAttribute("CaptureDetails", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
       public CaptureDetails CaptureDetails { get; set; }
    
       [XmlElementAttribute("DeployDetails", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
       public DeployDetails DeployDetails { get; set; }

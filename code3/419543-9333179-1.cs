    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class DeployDetails
    {
       public DeployDetails()
       {
          this.DeployRuns = new DeployRuns();
       }
    
       [System.Xml.Serialization.XmlAttributeAttribute("sourcePath")]
       public string SourcePath { get; set; }
    
       [System.Xml.Serialization.XmlAttributeAttribute("archiveDestinationPath")]
       public string ArchiveDestinationPath { get; set; }
    
       [System.Xml.Serialization.XmlAttributeAttribute("databaseDestinationPath")]
       public string DatabaseDestinationPath { get; set; }
    
       public DeployRuns DeployRuns { get; set; }
    }

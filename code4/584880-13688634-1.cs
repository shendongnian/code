    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ProductUpdatesItem {
        
    private ProductUpdatesItemArtifact[] artifactField;
    
    private string nameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Artifact", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ProductUpdatesItemArtifact[] Artifact {
        get {
            return this.artifactField;
        }
        set {
            this.artifactField = value;
        }
    }

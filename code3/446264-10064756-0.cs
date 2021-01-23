    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://usdoj.gov/leisp/lexs/3.1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://usdoj.gov/leisp/lexs/3.1", IsNullable=false)]
    public partial class PublishMessageContainer {
    	
    	private PublishMessageContainerPublishMessage[] publishMessageField;
    	
    	/// <remarks/>
    	[System.Xml.Serialization.XmlElementAttribute("PublishMessage")]
    	public PublishMessageContainerPublishMessage[] PublishMessage {
    		get {
    			return this.publishMessageField;
    		}
    		set {
    			this.publishMessageField = value;
    		}
    	}
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://usdoj.gov/leisp/lexs/3.1")]
    public partial class PublishMessageContainerPublishMessage {
    	
    	private string pDMessageMetadataField;
    	
    	/// <remarks/>
    	public string PDMessageMetadata {
    		get {
    			return this.pDMessageMetadataField;
    		}
    		set {
    			this.pDMessageMetadataField = value;
    		}
    	}
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://usdoj.gov/leisp/lexs/3.1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://usdoj.gov/leisp/lexs/3.1", IsNullable=false)]
    public partial class doPublish {
    	
    	private PublishMessageContainer[] itemsField;
    	
    	/// <remarks/>
    	[System.Xml.Serialization.XmlElementAttribute("PublishMessageContainer")]
    	public PublishMessageContainer[] Items {
    		get {
    			return this.itemsField;
    		}
    		set {
    			this.itemsField = value;
    		}
    	}
    }

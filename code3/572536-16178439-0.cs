    using System.Xml.Serialization;
    using System.IO;
    using System;
    
    class App
    {
      static void Main()
      {
        StreamReader fs = new StreamReader(@"sample.xml");
        XmlSerializer serializer = new XmlSerializer(typeof(PhysDocDocument));
        var result = serializer.Deserialize(fs) as PhysDocDocument;  
        Console.WriteLine(result);
      }
    }
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class PhysDocDocument
    {
    
        private PhysDocDocumentPhysDocNode[] itemsField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PhysDocNode", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PhysDocDocumentPhysDocNode[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class PhysDocDocumentPhysDocNode
    {
    
        private string linkedPluginIdField;
    
        private PhysDocDocumentPhysDocNodePlugin[] pluginField;
    
        private string headerVisibleField;
    
        private string displayField;
    
        private string isCollapsedField;
    
        private string copyForwardEnabledField;
    
        private string isHiddenField;
    
        private string bordersField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LinkedPluginId
        {
            get
            {
                return this.linkedPluginIdField;
            }
            set
            {
                this.linkedPluginIdField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Plugin", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PhysDocDocumentPhysDocNodePlugin[] Plugin
        {
            get
            {
                return this.pluginField;
            }
            set
            {
                this.pluginField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string HeaderVisible
        {
            get
            {
                return this.headerVisibleField;
            }
            set
            {
                this.headerVisibleField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Display
        {
            get
            {
                return this.displayField;
            }
            set
            {
                this.displayField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IsCollapsed
        {
            get
            {
                return this.isCollapsedField;
            }
            set
            {
                this.isCollapsedField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CopyForwardEnabled
        {
            get
            {
                return this.copyForwardEnabledField;
            }
            set
            {
                this.copyForwardEnabledField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IsHidden
        {
            get
            {
                return this.isHiddenField;
            }
            set
            {
                this.isHiddenField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Borders
        {
            get
            {
                return this.bordersField;
            }
            set
            {
                this.bordersField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("PromptPlugin")]
    public partial class PhysDocDocumentPhysDocNodePlugin
    {
    
        private string copyForwardCheckedField;
    
        private PhysDocDocumentPhysDocNodePluginPromptBase[] promptBaseField;
    
        private string idField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CopyForwardChecked
        {
            get
            {
                return this.copyForwardCheckedField;
            }
            set
            {
                this.copyForwardCheckedField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PromptBase", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PhysDocDocumentPhysDocNodePluginPromptBase[] PromptBase
        {
            get
            {
                return this.promptBaseField;
            }
            set
            {
                this.promptBaseField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("MemoPrompt")]
    public partial class PhysDocDocumentPhysDocNodePluginPromptBase
    {
    
        private string labelField;
    
        private string showLabelField;
    
        private string renderHeaderField;
    
        private PhysDocDocumentPhysDocNodePluginPromptBaseDocumentValue[] documentValueField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ShowLabel
        {
            get
            {
                return this.showLabelField;
            }
            set
            {
                this.showLabelField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RenderHeader
        {
            get
            {
                return this.renderHeaderField;
            }
            set
            {
                this.renderHeaderField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DocumentValue", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PhysDocDocumentPhysDocNodePluginPromptBaseDocumentValue[] DocumentValue
        {
            get
            {
                return this.documentValueField;
            }
            set
            {
                this.documentValueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class PhysDocDocumentPhysDocNodePluginPromptBaseDocumentValue
    {
    
        private string paragraphsField;
    
        private PhysDocDocumentPhysDocNodePluginPromptBaseDocumentValueDefaultFont[] defaultFontField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Paragraphs
        {
            get
            {
                return this.paragraphsField;
            }
            set
            {
                this.paragraphsField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DefaultFont", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PhysDocDocumentPhysDocNodePluginPromptBaseDocumentValueDefaultFont[] DefaultFont
        {
            get
            {
                return this.defaultFontField;
            }
            set
            {
                this.defaultFontField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class PhysDocDocumentPhysDocNodePluginPromptBaseDocumentValueDefaultFont
    {
    
        private string fontFamilyField;
    
        private string sizeInPointsField;
    
        private string styleField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FontFamily
        {
            get
            {
                return this.fontFamilyField;
            }
            set
            {
                this.fontFamilyField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SizeInPoints
        {
            get
            {
                return this.sizeInPointsField;
            }
            set
            {
                this.sizeInPointsField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Style
        {
            get
            {
                return this.styleField;
            }
            set
            {
                this.styleField = value;
            }
        }
    }

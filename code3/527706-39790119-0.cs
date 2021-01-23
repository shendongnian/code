    /// <summary>
    /// <para>Complex root type.</para>
    /// <para>Information root.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("root", Namespace="http://example.org/annotations")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("root", Namespace="http://example.org/annotations")]
    public partial class Root
    {
            
        /// <summary>
        /// <para>
        ///            Test data in element.
        ///          </para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 50.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(50)]
        [System.Xml.Serialization.XmlElementAttribute("TestElement", Namespace="http://example.org/annotations")]
        public string TestElement { get; set; }
            
        /// <summary>
        /// <para>
        ///          Optional test data in attribute.
        ///        </para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 50.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(50)]
        [System.Xml.Serialization.XmlAttributeAttribute("TestAttribute", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TestAttribute { get; set; }
    }

    [XmlElement(ElementName = "ValueArray", Type = typeof(ValueArrayType), Namespace = "YourSchemaNamespace")]
            public ValueArrayType[] ValueArray
            {
                get
                {
                    return this.valueArrayField;
                }
                set
                {
                    this.valueArrayField = value;
                }
            }

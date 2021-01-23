            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
            public partial class VINquery
            {
    
                private VINqueryVIN vINField;
    
                private string versionField;
    
                private string dateField;
    
                /// <remarks/>
                public VINqueryVIN VIN
                {
                    get
                    {
                        return this.vINField;
                    }
                    set
                    {
                        this.vINField = value;
                    }
                }
    
                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string Version
                {
                    get
                    {
                        return this.versionField;
                    }
                    set
                    {
                        this.versionField = value;
                    }
                }
    
                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string Date
                {
                    get
                    {
                        return this.dateField;
                    }
                    set
                    {
                        this.dateField = value;
                    }
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            public partial class VINqueryVIN
            {
    
                private VINqueryVINVehicle vehicleField;
    
                private string numberField;
    
                private string statusField;
    
                /// <remarks/>
                public VINqueryVINVehicle Vehicle
                {
                    get
                    {
                        return this.vehicleField;
                    }
                    set
                    {
                        this.vehicleField = value;
                    }
                }
    
                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string Number
                {
                    get
                    {
                        return this.numberField;
                    }
                    set
                    {
                        this.numberField = value;
                    }
                }
    
                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string Status
                {
                    get
                    {
                        return this.statusField;
                    }
                    set
                    {
                        this.statusField = value;
                    }
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            public partial class VINqueryVINVehicle
            {
    
                private VINqueryVINVehicleItem[] itemField;
    
                private ushort vINquery_Vehicle_IDField;
    
                private ushort model_YearField;
    
                private string makeField;
    
                private string modelField;
    
                private string trim_LevelField;
    
                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute("Item")]
                public VINqueryVINVehicleItem[] Item
                {
                    get
                    {
                        return this.itemField;
                    }
                    set
                    {
                        this.itemField = value;
                    }
                }
    
                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public ushort VINquery_Vehicle_ID
                {
                    get
                    {
                        return this.vINquery_Vehicle_IDField;
                    }
                    set
                    {
                        this.vINquery_Vehicle_IDField = value;
                    }
                }
    
                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public ushort Model_Year
                {
                    get
                    {
                        return this.model_YearField;
                    }
                    set
                    {
                        this.model_YearField = value;
                    }
                }
    
                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string Make
                {
                    get
                    {
                        return this.makeField;
                    }
                    set
                    {
                        this.makeField = value;
                    }
                }
    
                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string Model
                {
                    get
                    {
                        return this.modelField;
                    }
                    set
                    {
                        this.modelField = value;
                    }
                }
    
                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string Trim_Level
                {
                    get
                    {
                        return this.trim_LevelField;
                    }
                    set
                    {
                        this.trim_LevelField = value;
                    }
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            public partial class VINqueryVINVehicleItem
            {
    
                private string keyField;
    
                private string valueField;
    
                private string unitField;
    
                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string Key
                {
                    get
                    {
                        return this.keyField;
                    }
                    set
                    {
                        this.keyField = value;
                    }
                }
    
                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string Value
                {
                    get
                    {
                        return this.valueField;
                    }
                    set
                    {
                        this.valueField = value;
                    }
                }
    
                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string Unit
                {
                    get
                    {
                        return this.unitField;
                    }
                    set
                    {
                        this.unitField = value;
                    }
                }
            }

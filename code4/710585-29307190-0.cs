    private XmlCDataSection foo;
    [System.Xml.Serialization.XmlElementAttribute(Order=2)]
    public XmlCDataSection foo {
        get {
            return this.foo;
        }
        set {
            this.foo = value;
            this.RaisePropertyChanged("foo");
        }
    }

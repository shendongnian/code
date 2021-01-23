    public Model() : this(null) {
      // call public Model(XElement element = null)
    }
    public Model(XElement element) {
      // do some validation (XName)element.Name
      this.Element = element ?? new XElement("Model");
      //this.Element.Changing += Element_Changing;
      this.Element.Changed += Element_Changed;
    }

    static Attribute[] AddAttribute(Attribute[] attributes, Attribute attr) {
        Array.Resize(ref attributes, attributes.Length + 1);
        attributes[attributes.Length - 1] = new attr;
        return attributes;
    }
    public MyPropertyDescriptor(MemberDescriptor propDef)
           : base(propDef, AddAttribute(propDef.Attributes, new DataMembeAttribute()))

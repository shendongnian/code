    // XmlInclude is necessary because our class doesn't explicitly mention derived object
    [XmlInclude(typeof(ObjectDerived))]
    class MyRootClass {
        public ObjectBase { get; set; }
    }
    class ObjectBase {
        // some properties here
    }
    class ObjectDerived : ObjectBase {
        // more properties here
    }
    ...
    var serializer = new XmlSerializer(typeof(MyRootClass));

    [XmlRoot]
    public class FooSurrogate {
         public FooSurrogate() { }; // note the empty constructor for xml deserialization
         public FooSurrogate(Foo foo) {  // this constructor is used in step 2
              // in here you copy foo's state into this object's state
              this.Prop1 = foo.Prop1; // this prop can be copied directly 
              this.Bar = new BarSurrogate(foo.Bar); // this prop needs a surrogate as well  
         } 
 
         [XmlAttribute]  // note your surrogate can be used to xml-format too!
         public string Prop1 { get; set; }
     
         [XmlElement]
         public BarSurrogate Bar { get; set; }
    }
    public class BarSurrogate { 
    ...
    }

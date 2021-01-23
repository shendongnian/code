    public class Model {
       protected XElement Element {
         get; set;
       }
       public Model() : this(null) { }
       public Model(XElement element) {
         // do some validation (XName)element.Name
         this.Element = element ?? new XElement("Model");
       }
       public string Name {
         get {
           return (string)Element.Attribute("Name");
         }
         set {
           Element.SetAttribute(value);
         }
       }
    }

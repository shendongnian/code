    public class SoapThing
    {
    ...
    }
    SoapThing p=new SoapThing ();
          p.x = some values;
          System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(p.GetType());
          x.Serialize(Console.Out, p);

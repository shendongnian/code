    public class XmlPersonRepository {
      private readonly IXmlDataGetter _getter;
    
      public PersonFetcher(IXmlDataGetter getter) {
        _getter = getter;
      }
    
      Person GetFromId(int id) {
        var xmlData = _getter.GetData(new XmlDataName("PERSON", id));
        return ConvertToPerson(xmlData); 
      }
    }

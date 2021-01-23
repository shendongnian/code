    public class FileXmlDataGetter : IXmlDataGetter {
      XmlData GetData(XmlDataName name) {
        return ContentsOfFile(name.first /* PERSON */ + "_" + name.second /* 25 */ + ".xml"); 
      }
    }

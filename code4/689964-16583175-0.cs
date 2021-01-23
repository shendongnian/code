    public class DataList
    {
        public List<Pandora.Data.DomainObject> Data {get; set;}
        public string Name {get; set;}
    }
...
    static List<string> GatherDataPerProduct(DataList lstdata)
    {
        if(lstData.Name == "subjects")
        ....
    }

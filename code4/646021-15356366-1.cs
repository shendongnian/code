    public class AnObject()
    {
        SomeProperty {get; set;}
        Some Method(); 
    }
    public class theCollectionofAnObject : IList<AnObject> ()
    {
        private List<AnObject> _contents = new List<AnObject>;
        //Implement the rest of IList interface
    }
    //Your async method
    public Task<theCollectionofAnObject> GetAnObjects(parameter)
    {
    }

    public class SomeListClass
    {
        public ObjectId id { get; set; }
        public List<string> Images { get; set; }
    }
----------
    SomeListClass slc = new SomeListClass();
    slc.Images = someList;
    //inserting a new document is done with serialization 
    collection.Insert(slc);
    //Saving an existing document also uses serialization (as long as you have an id)
    var id = slc.id;
    slc.Images = someModifiedList;
    collection.Save(slc);

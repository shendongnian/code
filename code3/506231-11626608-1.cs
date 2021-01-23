    public class SomeListClass
    {
        public ObjectId id { get; set; }
        public List<string> Images { get; set; }
    }
----------
    SomeListClass slc = new SomeListClass();
    slc.Images = someList;
    collection.Save(slc);

    [DataContract]
    public class Foo {
        [DataMember(Order=1)] public int Id {get;set;}
        [DataMember(Order=2)] public string Name {get;set;}
        // ... more props
        // IMPORTANT: make this representative - basically, the same data
        // that you had in the data-table
        // note also include any supporting info - any indexers and interface
        // support that your core code needs
    }
    [DataContract]
    public class FooWrapper { // just to help in the test
         [DataMember(Order=1)] public List<Foo> Items {get;set;}
    }

    namespace MyApp.DataModel
    {
        //It is not mandatory to specify the DataContract since a default one will be
        //provided on recent version of .Net, however it is a good practice to do so.
        [DataContract(Name = "MyClassDataModel", Namespace = "MyApp.DataModel")]
        public class MyClassDataModel
        {
            [DataMember]
            public bool DataMemberExample{ get; set; }
        }
    
    }

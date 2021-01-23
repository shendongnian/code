    public class MyViewModel
    {
        public string name { get; set; }
        public string someprop1 { get; set; }
        public string someprop2 { get; set; }
        public MyAddress visitingaddress { get; set; }
        public MyAddress postaladdress { get; set; }
        public MyContactAddress contactaddress { get; set; }
    }
    public class MyAddress
    {
        public string town { get; set; }
        public string street { get; set; }
        public string housenumber { get; set; }
        public string postalcode { get; set; }
    }
    public class MyContactAddress : MyAddress
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
    }

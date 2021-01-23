    public class YourClass
    {
        public string Property1NameHere { get; set; }
        public string Property2NameHere { get; set; }
    }
    List<YourClass> myList = new List<YourClass>(); 
    using (StreamReader sr = new StreamReader(selection)) 
    { 
        while ((line = sr.ReadLine()) != null) 
        { 
            ...
            YourClass yourClass = new YourClass() { ... };
            myList.Add(yourClass);  
        }
    }
    dataGrid1.ItemsSource = myList; 

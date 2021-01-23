    public class MyModel
    {
        private List<MyOtherObject> _TheListOfOtherObjects;
        public List<MyOtherObject> TheListOfOtherObjects {
            get { return _TheListOfOtherObjects; }
            set { _TheListOfOtherObjects = value; GetListOfMyOtherIvjectIDs(); }
        }
    
        public List<int> MyOtherObjectIDs { get; set; }
    
        public void GetListOfMyOtherObjectIDs() 
        {
           // function that extracts the IDs of objects in
           // the list and assigns it to MyOtherObjectIDs
        }
    }

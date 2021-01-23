    [Serializable]
    public class S
    {
        IList<T> _listofTs;
        [XmlIgnore]
        public IList<T> ListOfTs { get _listofTs; set _listofTs = value; }
        [XmlElement(Name="Not Exactly the Greatest Solution!")]
        public List<T> ListOfTs { get _listofTs; set _listofTs = value; }
    
        public S()
        {
            ListOfTs = new List<T>();
        }
    }

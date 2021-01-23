    public enum E
    {
        One, 
        Two
    }
    
    [DataContract]
    public class C
    {
        [DataMember]
        private string myField;
    
        public E MyProperty 
        {
            get 
            { 
                E result;
                return Enum.TryParse<E>(myField, out result) ? result : default(E);
            }
            set { myField = value.ToString(); }
        }
    }

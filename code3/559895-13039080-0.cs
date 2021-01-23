    public class FruitBasket
    {
        private List<string> _fruitList;
        [DataMember]
        public List<string> FruitList
        {
            get
            {
                return _fruitList;
            }
            set
            {
                if (value == null)
                {
                    _fruitList = new List<string>();
                }
                else
                {
                    _fruitList = value;
                }
            }
        }
        public int FruitCount
        {
            get
            {
                return FruitList.Count();
            }
        }
    } 

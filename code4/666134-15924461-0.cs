     public class Card
     {
        public string Name { get; set; }
        public override string ToString()
        {
             return string.Format("CardName: {0}", Name);
        }
     }

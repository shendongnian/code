      public class Order
      {
        public int Id;
        public string SomeProp;
        public string AnotherProp;
        public override bool Equals(object obj)
        {
          Order orderToCompare = (Order)obj;
          return (SomeProp == orderToCompare.SomeProp && AnotherProp == orderToCompare.AnotherProp);
        }
      }

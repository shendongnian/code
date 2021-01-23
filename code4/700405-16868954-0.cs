    public class Header
    {
        public int HeaderId { get; set; }
        public virtual List<Detail> Details { get; set; }
        public int SumOfDetailQuantities
        {
            get { return Details.Sum(x => x.Quantity); }
        }
    }

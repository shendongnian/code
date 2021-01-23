    public class MyType
    {
        public IList<MyType> Childrens { get; set; }
        public int Order { get; set; }
        public void RecursiveOrder()
        {
            Childrens = Childrens.OrderBy(x => x.Order)
                .ToList();
            Childrens.ToList().ForEach(c => c.RecursiveOrder());
        }
    } 

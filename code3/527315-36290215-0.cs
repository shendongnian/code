    public class MyViewModel {
        [BindableProperty]
        public virtual IList<Products> ProductsList{ get; set; }
        public MyViewModel ()
        {
            ProductsList.Clear(); // here is the problem
        }
    }

    public class AppDetailModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    
    
        public class AppDetailViewModel : AppDetailModel
        {
            public string ViewProperty { get; set; }
        }

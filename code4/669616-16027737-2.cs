      public class GridViewModel
        {
            public string Name { get; set; }
    
            public CellViewModel Pitts { get; set; }
    
            public CellViewModel Vans { get; set; }
    
            public CellViewModel Lancair { get; set; }
    
            public CellViewModel Epic { get; set; }
        }
    
        public class CellViewModel
        {
            public string Name { get; set; }
    
            public string ImageSource { get; set; }
    
            public decimal Value { get; set; }
        }

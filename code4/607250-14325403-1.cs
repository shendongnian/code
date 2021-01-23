    public class MyList<T> : List<T>
    {
        public string ItemRequestStatus { get; set; } // Determines the change status if applicable
        public bool IsButtonEnabled { get; set; } // Determines if the delete button is enabled or disabled
        public MyList()
        {
            
        }
        public MyList(IList<T> list)
            : base(list)
        {
            
        }
    }

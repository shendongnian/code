    public class YourOriginalClass
    {
        /// <summary>
        /// The list you want to access
        /// </summary>
        public List<YourType> YourList { 
           get; 
           set; 
        }
    }
    // Here another class where you can use the list
    public class YourSecondClass
    {
        public void EditMyList()
        {
           YourOriginalClass test = new YourOriginalClass();
           test.YourList = new List<YourType>();
           // then you can populate it
        }
    }

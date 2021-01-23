    public class MyViewModel
    {
        [System.ComponentModel.DataAnnotations.RegularExpression("[a-zA-Z]+")]
        public string MyEntry
        {
           get;
           set;
        }
    }

    public class Model
    {
        public string pcode { get; set; }
        public string pname { get; set; }
        public string ConcatDescription { get; set; }
    
        public string ConcatDescription 
        {
            get 
            {
                return string.Format("{0} {1}", pcode , pname );
            }
        }
    }

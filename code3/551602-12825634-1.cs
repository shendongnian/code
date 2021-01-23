    public class id           
    {      
        [Required]           
        public decimal l_ID           
        {           
            get;           
            set;           
        }           
           
        [Required]   
        [GreaterThanOtherAttribute("l_ID")]        
        public decimal v_ID           
        {           
            get;           
            set;           
        }           
    }     

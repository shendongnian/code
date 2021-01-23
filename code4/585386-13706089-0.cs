    public class MVCMODEL
    {
        [Required] 
        [MaxLenght(300)] // number of characters allowed in this field.
        public  int Name{ get; set; }
    }

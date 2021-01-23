    public class ApplicationDTO : BaseDTO
    {
       [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
       public DateTime Date { get; set; }
       public int JobId {get;set;}
       public int Status {get;set;}
       [Required]
       public string Message { get; set; }
       public string ExpertCode { get; set; }
    }

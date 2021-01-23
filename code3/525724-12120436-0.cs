     public class Reference : AuditableTable
        {
            [Range(0, 99, ErrorMessage = "{0} must be between {1} and {2}")]
            [DisplayName("Order")]
            public int Range { get; 
            set { 
           if((value < 0) || (value > 99))
            {
            throw new Exception(string.Format("{0} must be between 0 and 99",value.ToString()));
            }
            else
            {
            Range = value;
            }
            }
        }

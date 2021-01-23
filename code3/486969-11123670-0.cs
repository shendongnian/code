    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    public class TestModel
    {
        [Display(Name="Schedule Name")]
        [Required]
        public string scheduleName { get; set; }
    }

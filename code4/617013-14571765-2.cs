    public class MiageQuotaRequestViewModel
    {
        [Required]
        [UIHint("Number")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Nombre de place demandées", Prompt = "Nombre de place")]
        [Range(0, 50, ErrorMessage = "La demande doit être comprise entre 0 et 50 places")]
        public int? RequestedQuota { get; set; }
    }

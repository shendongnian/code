        public class ContactEmailAddressDto
        {
            public int ContactId { get; set; }
            [Required]
            [Display(Name = "New Email Address")]
            [EmailAnnotation] //**<----- Nifty.**
            public string EmailAddressToAdd { get; set; }
        }

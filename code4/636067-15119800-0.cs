        [DisplayName("Daily Print Time")]
        [RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9][\\s]*[apAP][mM][\\s]*", ErrorMessage="Invalid Time Format")]
        [Required]
        public string sPrintTime { get; set; }
        [DisplayName("Daily Print Time")]
        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        [Required]
        public System.DateTime PrintTime { get; set; }

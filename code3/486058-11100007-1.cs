    public class Meeting
    {
        [Key]
        public int MeetingId { get; set; }
 
        [Required]
        public DateTime Start { get; set; }
 
        [Required]
        public DateTime End { get; set; }
 
        [Required]
        [StringLength(80, MinimumLength = 5)]
        public string Title { get; set; }
 
        public string Details { get; set; }
 
        [Required]
        [RegularExpression(@"\d{1,3}/\d{4}",
        ErrorMessage = "{0} must be in the format of 'Building/Room'")]
        public string Location { get; set; }
 
        [Range(2, 100)]
        [Display(Name = "Minimum Attendees")]
        public int MinimumAttendees { get; set; }
 
        [Range(2, 100)]
        [Display(Name = "Maximum Attendees")]
        public int MaximumAttendees { get; set; }
    }

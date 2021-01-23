    public class CreateJob
    {
        [Required]
        public int JobTypeId { get; set; }
        public string RequestedBy { get; set; }
        [MinLength(1)]
        public JobTask[] TaskDescriptions { get; set; }
    }

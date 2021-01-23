        public class Submission
        {
            public int SubmissionId { get; set; }
            public string Title { get; set; }
        }
        public class EditSubmissionModel
        {
            public string foo { get; set; }
            public Submission submission { get; set; }
        }

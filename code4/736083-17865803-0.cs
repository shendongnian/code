    using System.ComponentModel.DataAnnotations;
    public enum TaskStatus{
       [Display(Name = "Waiting for approval")]
       WaitinForApproval,
       [Display(Name = "Submitted for review")]
       SubmittedForReview,
       .....
      }
    
    

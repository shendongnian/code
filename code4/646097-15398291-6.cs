    public class UserDetail 
     {
         //This is property mapping, UserId will be the same as the Membership UserId and UserProfile UserId
         [Key]
         [ForeignKey("UserProfile")]
         [HiddenInput(DisplayValue = false)]
         public int UserId { get; set; }
         public string FirstName{get;set;}    
         public string LastName{get;set;}
         public UserProfile UserProfile { get; set; } 
     }

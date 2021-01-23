    public class SocialProvider
    {
       public int Id { get; set; }        
       
       public string AccessToken { get; set; }       
      
       [ForeignKey("Provider"), DatabaseGenerated(DatabaseGeneratedOption.None)]
       public string ProviderId { get; set; }
       public Provider Provider { get; set; }
       [ForeignKey("User"), DatabaseGenerated(DatabaseGeneratedOption.None)]
       public string UserId { get; set; }
       // The user that this SocialProvider belongs to.
       public virtual User User { get; set; }
       // The users that have this social provider as a contact.
       public virtual ICollection<User> Contacts { get; set; }
    }

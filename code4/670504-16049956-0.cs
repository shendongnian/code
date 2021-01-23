    public class User
    {
       public int Id { get; set; }
       ublic string Password { get; set; }
       public string Name { get; set; }
       
       // Collection that represent this user's attached social providers.
       public virtual ICollection<SocialProvider> SocialProviders { get; set; }
       // Collection representing this user's friends from her attached social providers.
       public virtual ICollection<SocialProvider> SocialContacts { get; set; }
    }

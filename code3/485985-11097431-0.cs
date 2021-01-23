    public class MyPage : Page
    {
       public User User { get; set; }
    
       public void Page_Load()
       {
          // logic to fetch the user from your persistence store
          // e.g. User = MyUserRepo.Fetch(uid);
          
          // Important
          DataBind();
       }
    
       public string GetHelloMessage()
       {
            // this is straight forward, alternatively you could have  some logic here to 
            // derive which which message is shown to the user
            litHelloMessage = GetLocalResourceObject(User.MessageResourceKey).ToString();
       }
    }

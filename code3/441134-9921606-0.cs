    public class LoginViewController : UITableViewController
    {
      LoginDataSource m_loginDataSource;
      public bool m_receivedMemoryWarning;
      public LoginViewController(UITableViewStyle withStyle) : base(withStyle)
      {
       m_receivedMemoryWarning = false;
       m_loginDataSource = new LoginDataSource(this);
       TableView.Source = m_loginDataSource;
      }
      public override void LoadView()
      {
        this.View = new UITableView(UIScreen.MainScreen.ApplicationFrame,  UITableViewStyle.Grouped);
      }
       public override void ViewWillAppear(bool animated)
       {
        base.ViewWillAppear (animated);
      
        if (m_receivedMemoryWarning)
        {
         m_loginDataSource = new LoginDataSource(this);
         TableView.Source = m_loginDataSource;
         TableView.ReloadData();
         m_receivedMemoryWarning = false;
       }
     public override void DidReceiveMemoryWarning ()
      {
       m_receivedMemoryWarning = true;
       base.DidReceiveMemoryWarning ();
     }
    }

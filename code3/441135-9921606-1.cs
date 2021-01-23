    public class LoginViewController : UITableViewController
    {
      LoginDataSource m_loginDataSource;
      public LoginViewController(UITableViewStyle withStyle) : base(withStyle)
      {
       m_loginDataSource = new LoginDataSource(this);
      }
      public override void LoadView()
      {
        this.View = new UITableView(UIScreen.MainScreen.ApplicationFrame,  UITableViewStyle.Grouped);
      }
      public override void ViewDidLoad ()
      {
        base.ViewDidLoad ();
        TableView.Source = m_loginDataSource;
      }
    }

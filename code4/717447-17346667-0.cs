    using System.Web.Hosting;
    protected void Page_Load(object sender, EventArgs e)
    {
       using (HostingEnvironment.Impersonate())
       {
          string FirstName = UserPrincipal.Current.Surname.ToString();
          string LastName = UserPrincipal.Current.GivenName.ToString();
          Label1.Text = LastName + " " + FirstName;
       }
    }

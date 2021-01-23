    public class MyApp
    {
      public string Image1;
      public string Image2;
      public string Image3;
      protected void Page_Load(object sender, EventArgs e)
      {
        if (!Page.IsPostBack)
        {
          lblRow.Text = Request.QueryString["num"];
          Image1 = Request.QueryString["ImageAlt1"];
          Image2 = Request.QueryString["ImageAlt2"];
          Image3 = Request.QueryString["ImageAlt3"];
        }
      }
    }

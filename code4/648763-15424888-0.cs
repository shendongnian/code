    public class YourPage : System.Web.UI.Page
    {
          protected bool AreControlsCreated {
          {
              get{return (bool)ViewState["AreControlsCreated"];}
              set{ViewState["AreControlsCreated"] = value;}
          }
          private void Page_Load(object sender, System.EventArgs e)
          {
              if(!IsPostBack)
              {
                  AreControlsCreated = false;
              }
              else if(AreControlsCreated)
              {
                  CreateYourControls();
              }
          }
          private void CreateYourControls()
          {
            ...
            FileUpload fu = new FileUpload();
            fu.ID = "fu";
            fu.EnableViewState = true;
            list.Add(fu);
            Button btnFu = new Button();
            btnFu.Text = "Upload";
            btnFu.ID = "btnFu";
            list.Add(btnFu);
            AreControlsCreated = true;
          }
          protected void YourButton_Click(object sender, EventArgs e)
          {
              createYourControls();
          }
    }

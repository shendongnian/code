        namespace KetBanBonPhuong
        {
               [AjaxPro.AjaxNamespace("Default")]
    
               public partial class Default1 : System.Web.UI.Page
               {
                   protected void Page_Load(object sender, EventArgs e)
                   {
                        AjaxPro.Utility.RegisterTypeForAjax(typeof(Default1));
                        if(!isPostBack)
                        {
                    DataList dl = new DataList();
                    dl.DataSource = GetList();
                    dl.DataBind();
                    this.liststatus.Controls.Add(dl);
                    dl.DataSource = GetList();
                    dl.RepeatLayout = RepeatLayout.Flow;
                    Literal ltr = new Literal();
                    ltr.Text = "kaldfs";
                    
                    dl.Controls.Add(ltr);//Error here
                 }
              }
    }

    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace WebApplication1
    {
        public partial class WebForm2 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                Label1.Text = "Load";
            }
            public void btn_remove_Click(object sender, EventArgs e)
            {
                for (int i = 0; i < UPCList.Items.Count; i++)
                {
                    if (UPCList.Items[i].Selected == true)
                    {
                        UPCList.Items.RemoveAt(i);
                    }
                }
                Label1.Text = "Done";
            }
        }
    }

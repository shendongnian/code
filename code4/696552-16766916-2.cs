	using System;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	namespace WebApplication1
	{
		public partial class WebForm2 : System.Web.UI.Page
		{
			protected void Page_Load(object sender, EventArgs e)
			{
			}
			protected void Timer1_Tick(object sender, EventArgs e)
			{
				labelform.Text = DateTime.Now.ToString();
			 //  UpdatePanel1.Update();
				Label lblmaster = this.Master.FindControl("lblmaster") as Label;
				lblmaster.Text = DateTime.Now.ToString();
			}
		}
	}

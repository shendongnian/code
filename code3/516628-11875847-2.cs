	public partial class Default : System.Web.UI.Page
	{
		protected void Page_load(object sender, EventArgs e)
		{
			Ajax.Utility.RegisterTypeForAjax(typeof(Default));
		}
		
		[Ajax.AjaxMethod]
		public void DoThing()
		{
			Thread thread = new Thread(new ThreadStart(MyTimeConsumingProcess));
			thread.Start();
			//The MyTimeConsumingProcess updates a var for thing progess
		}
		
		[Ajax.AjaxMethod]
		private String ThingProgress()
		{
			//Reads some var
			return progressNumber + "%"
		}
	}

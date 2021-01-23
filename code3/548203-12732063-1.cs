		//HERE YOU ARE ATTACHING TO THE REPEATER'S ITEMDATABOUND EVENT
		//THIS ALLOWS YOU TO CONTROL THE OUTPUT FOR EACH ACCIDENT
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			this.rptAccidents.ItemDataBound += rptAccidents_ItemDataBound;
		}
		//THIS IS THE CODE THAT WILL RUN FOR EACH DATA ITEM IN THE REPEATER'S DATA SOURCE
		void rptAccidents_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			//in this case, you only care about the item templates
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				//cast your dataitem here
				Accident data = (Accident)data;
				//find the appropriate textbox (or any other control that is runat="server", and set the value.
				((TextBox)e.Item.FindControl("txtNature")).Text = data.Nature;
				((TextBox)e.Item.FindControl("txtDate")).Text = data.Date;
			}
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this.rptAccidents.DataSource = //I AM NOT SURE WHERE YOU ARE STORING THE DATA. BUT HERE IS WHERE YOU WOULD SET THE REPEATERS DATA SOURCE
				this.rptAccidents.DataBind(); //THIS LINE CAUSES THE REPEAT TO BIND ITSELF TO YOUR DATA SOURCE
			}
		}

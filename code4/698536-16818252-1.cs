		public string Id
		{
			set
			{
				ShowHandler _show = new ShowHandler(Show);
				if (_show != null)
				{
					_show(value);
				}
			}
		}
		protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			//set of existing code
			Id = visadagbok
		}
		public void Show(string Id)
		{
			//set of code
		}

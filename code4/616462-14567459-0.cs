		private enum PageStates
		{
			None = 0,
			View = 1,
			Edit = 2
		}
		/// <summary>
		/// The current state of the page
		/// </summary>
		private PageStates PageState
		{
			get
			{
				if (ViewState["PageState"] == null)
					ViewState["PageState"] = PageStates.View; //default to view state
				return (PageStates)ViewState["PageState"];
			}
			set
			{
				ViewState["PageState"] = value;
			}
		}

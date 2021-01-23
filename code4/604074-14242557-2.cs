            [HttpPost]
    		public ActionResult Index(Model viewModel)
    		{
    			foreach (var item in viewModel.MyItems)
    			{
    				string columnOneValue = viewModel.MyItems[0].Key;
    				string columnTwoValue = viewModel.MyItems[0].Value; 
    			}

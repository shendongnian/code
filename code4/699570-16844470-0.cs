        public ActionResult Index()
        {
			var customerNameEncoded = "Justin's Instance";
			var url = Url.Action("ManageCustomer", new { customerName = customerNameEncoded });
			return Redirect(url);
        }
		public ActionResult ManageCustomer(string customerName)
		{
			ViewBag.CustomerName = customerName;
			return View();
		}

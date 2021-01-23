		public class Model
		{
			public Model()
			{
				List<SelectListItem> options = new List<SelectListItem>();
				options.Add(new SelectListItem { Value = true.ToString(), Text = "yes" });
				options.Add(new SelectListItem { Value = false.ToString(), Text = "no" });
				ContinueOptions = options;
			}
			public bool Continue { get; set; }
			public IEnumerable<SelectListItem> ContinueOptions { get; set; }
		}

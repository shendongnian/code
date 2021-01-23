    @using (Ajax.BeginForm("Index", "myController", new { param1 = 0, param2 = 1 }, new AjaxOptions { UpdateTargetId =    "Target", InsertionMode = InsertionMode.Replace, OnFailure = "error" }))
           {
                <input type="submit" />
                //more buttons
           }
        public ActionResult Index(String param1, String param2)
        {
           //do something
        }

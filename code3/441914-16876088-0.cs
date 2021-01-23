    @using (Ajax.BeginForm("Index", "myController", new { param1 = 0, param2 = 1 }, new AjaxOptions { UpdateTargetId =    "Target", InsertionMode = InsertionMode.Replace, OnFailure = "error" }))
           {
                <input type="submit" name="param2" id="param2" value="1" />
                //more buttons
           }
        public ActionResult Index(String param1, String param2)
        {
           //do something
        }

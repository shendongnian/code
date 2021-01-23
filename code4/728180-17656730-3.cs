    public static class Helpers
    {
        public static void GetDropdowns(this Controller controller)
        {
            // var username = controller.HttpContext.User.Identity.Name;
            // get name prefixes
            List<SelectListItem> prefixList = new List<SelectListItem>();
            prefixList.Add(new SelectListItem { Value = "Mr.", Text = "Mr." });
            prefixList.Add(new SelectListItem { Value = "Mrs.", Text = "Mrs." });
            prefixList.Add(new SelectListItem { Value = "Ms.", Text = "Ms." });
            controller.ViewBag.PrefixList = new SelectList(prefixList, "Value", "Text");
         }     
    }

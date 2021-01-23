    public static class Helper
    {
        public static string[] CheckBoxes
        {
            get
            {
                string [] result = System.Web.HttpContext.Current.Session["CheckBoxId"] as string[];
                if (result == null)
                {
                    result = new string[] { };
                }
                return result;
            }
            set
            {
                System.Web.HttpContext.Current.Session["CheckBoxId"] = value;
            }
        }
        public static void AddCheckBox(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }
            var checkboxes = CheckBoxes.ToList();
            checkboxes.Add(value);
            CheckBoxes = checkboxes.Distinct().ToArray();
        }
        public static void RemoveCheckBox(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }
            var checkboxes = CheckBoxes.ToList();
            checkboxes.RemoveAll(v => v == value);
            CheckBoxes = checkboxes.Distinct().ToArray();
        }
    }

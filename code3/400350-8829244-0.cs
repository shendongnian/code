    public static class Extensions
    {
        public static void SettingControls(this Form form)
        {
            List<Control> lstControls = GetAllControls(form.Controls);
            ...
        }
    }

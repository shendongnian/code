    public static class FormManager
    {
        public static void ShowForm(Type t)
        {
            var f = Activator.CreateInstance(t);
            ((Form)f).Show();
        }
    }

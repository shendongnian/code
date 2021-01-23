    //infrastructure - simulated with a static class
    public static class FormRepository
    {
        private static List<MyFormBase> _allForms = new List<MyFormBase>();
    
        public static void RegisterForm(MyFormBase form)
        {
            _allForms.Add(form);
        }
    
        public static void CloseFormAndChildren(MyFormBase form)
        {
            _allForms.Where(x => x.Parent.Equals(form)).ToList().ForEach(x => CloseFormAndChildren(x));
            form.Close();
        }
    }

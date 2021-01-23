    namespace Web.Services
    {
        public class MyServiceClass
        {
            public bool AddForm(XmlDocument form, string formName)
            {
                return FormsProcessing.Process(formName, form);
            }
        }
    }

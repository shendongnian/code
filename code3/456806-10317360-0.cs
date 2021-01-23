    public class MyRequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(string.Format("This is my error for {0}", name));
        }
    }

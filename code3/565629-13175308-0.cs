    public interface IValidateMyData
    {
        bool Validate();
    }
    public class ValidationControl : Control, IValidateMyData
    {
        // code here
        public bool Validate()
        {
            return true;
        }
    }

    public class EmployeeTransferForm: Form
    {
        public delegate Text GetTextHandler();
        GetTextHandler getSampleTextFromTextBox = null;
        public event GetTextHandler GetSampleTextFromTextBox
        {
            add { getSampleTextFromTextBox += value; }
            remove { getSampleTextFromTextBox -= value; }
        }
        
        //the rest of the code in the class
        //...
    }

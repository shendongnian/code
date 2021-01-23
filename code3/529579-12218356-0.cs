    public class MyClass
    {
    
        DateTime? LastDateValue = null;
        
        void OnLoad()
        {
           //Set both datepicker and LastDateValue to be the same
        }
        
        void DateTimePicker_valueChanged()
        {
           //use LastDateValue to save text fields
           //set LastDateValue to match new value ready to use on next event fire
        }
    
    }

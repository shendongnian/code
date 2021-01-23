    public class MyClass
    {
        private int _myCounter = 0;
    
        void checkBoxMethod (object sender, EventArgs args)
        {
            CheckBox box = (CheckBox)sender;
    
            //do whatever you need to do
    
            _myCounter++;
        }
        
    }

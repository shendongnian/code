    public class MyListBox : ListBox
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var returnValue = base.CreateParams;
                returnValue.Style |= 0x2; // LBS_SORT
                return returnValue;
            }
        }
    }

    public class MyListBox : ListBox
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var returnValue = base.CreateParams;
                returnValue.Style |= 0x2; // Add LBS_SORT
                returnValue.Style ^= 128; // Remove LBS_USETABSTOPS (optional)
                return returnValue;
            }
        }
    }

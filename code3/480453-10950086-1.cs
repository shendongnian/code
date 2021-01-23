    public class MyForm
    {
        // ...
        public void UpdateMe()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateMe));
                return;
            }
        
           // Code to update the control, guaranteed to be on the GUI thread
        }
    }

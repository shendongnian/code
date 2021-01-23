    public class PCCControls
    {
        public event EventHandler<PCCButtonPushedEventArgs> PCCButtonPushed;
        List<ControlBox> ControlBoxes;
        public void AddControlBox(ControlBox box) 
        {
            box.ButtonPushed += OnButtonPushed;
            ControlBoxes.Add(box);
        }
        public void RemoveControlBox(ControlBox box) 
        {
            box.ButtonPushed -= OnButtonPushed;
            ControlBoxes.Remove(box);
        }
        private void OnButtonPushed(object sender, EventArgs e)
        {
            var handler = PCCButtonPushed;
            if (handler != null) 
            {
               var box = (ControlBox)sender;
               handler(this, new PCCButtonPushedEventArgs(box));
            }
        }
    }  
    public class ControlBox
    {
        public event ButtonPushed;  
        public ProcessSub()
        {
            if(ButtonPushed != null) ButtonPushed(this, new EventArgs());
        }
    }

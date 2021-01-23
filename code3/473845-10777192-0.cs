    public class PCCControls
    {
        List<ControlBox> ControlBoxes;
    // initialization of ControlBoxes done elsewhere...
        public voice SomeMethod()
        {
            ControlBoxes.ElementAt(0).ButtonPushed += controlBox_ButtonPushed;
        }
        public void controlBox_ButtonPushed(object sender, EventArgs e)
        {
            // TODO:
        }
    }

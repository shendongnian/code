    public class GradientBox : Control
    {
        private Label myLabel;
        public GradientBox()
        {
            myLabel = new Label;
            // Set your default values
        }
        public Font Font
        {
            get { return myLabel.Font; }
            set { myLabel.Font = value; }
        }
        // repeat to expose just the properties you want.
     }
        

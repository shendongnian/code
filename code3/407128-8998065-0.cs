        public partial class UseUserControl : Form
        {
            public UseUserControl()
            {
                InitializeComponent();
                //Create the user control.
                TempUserControl userControl = new TempUserControl();
                //Add the location to the control.
                userControl.Location = new Point( 40, 40 );
                //Add the control to the current form.
                this.Controls.Add( userControl );
            }
        }

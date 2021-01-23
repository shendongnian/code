    public class OptionWindow
    {
        Form _mainWindow;                       //YOUR PROGRAM IS OF TYPE Form
        public OptionWindow(Form mainWindow)
        {
            this._mainWindow = mainWindow;
        }
        private void useOpacity_CheckedChanged(object sender, EventArgs e)
        {
             if (useOpacity.Checked)
             {
               _mainWindow.Opacity = .75;
             }
         }
    }

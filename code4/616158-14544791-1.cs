    public class MainForm:Forms
    {
        //Add two instance of the UserControls
        public MainForm()
        {
            this.firstUserControl.MyEvent += MainWindow_myevent;
        }
        void MainWindow_myevent(object sender, EventArgs e)
        {
            this.secondUserControl.MyText = this.firstUserControl.MyText;
        }
        //other codes
    }

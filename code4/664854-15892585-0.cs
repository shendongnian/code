     public partial class MainWindow : Window
    {
        public Button ControlToMove { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //create button
            ControlToMove = new Button();
            //add text to button
            ControlToMove.Content = "Click to move me to pop up window";
            //add a new routed event to the buttons click property
            ControlToMove.Click += new RoutedEventHandler(MoveControlToPopUp);
            //add control to the layout grid
            MainGrid.Children.Add(ControlToMove);
        }
        //This method moves the button to a popup window
        private void MoveControlToPopUp(object sender, RoutedEventArgs e)
        {
            //get the name of the control from sender
            var control = sender as Button;
            var controlName = control.Name;
            //checks to see if this is the control we want moved
            //if its not, method exits
            if (controlName != ControlToMove.Name) return;
            //create copy of the control
            var copiedControl = control;
            
            //remove control from existing window
            MainGrid.Children.Remove(control);
            //create pop up window
            var popUpWindow = new PopUpWindow(copiedControl);
            popUpWindow.Show();
        }
    }
    public class PopUpWindow : Window
    {
        public Grid Layout { get; set; }
        public PopUpWindow(Button button)
        {
            //create a grid for the new window
            Layout = new Grid();
            //add control to grid
            Layout.Children.Add(button);
            //add grid to window
            this.AddChild(Layout);
        }
    }

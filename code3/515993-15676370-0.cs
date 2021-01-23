    public partial class LoadingScreen : Form {
        private static Thread _LoadingScreenThread;
        private static LoadingScreen _ls;
        
        //condition required to check if the form has been loaded
        private static bool _shown = false;
        private static Form _parent;
        public LoadingScreen() {
            InitializeComponent();
        }
        //added the parent to the initializer
        //CHECKS FOR NULL HAVE NOT BEEN IMPLEMENTED
        public static void ShowLoadingScreen(string usercontrollname, Form parent) {
            // do something with the usercontroll name if desired
            _parent = parent;
            if (_LoadingScreenThread == null) {
                _LoadingScreenThread = new Thread(new ThreadStart(DoShowLoadingScreen));
                _LoadingScreenThread.SetApartmentState(ApartmentState.STA);
                _LoadingScreenThread.IsBackground = true;
                _LoadingScreenThread.Start();
            }
        }
        public static void CloseLoadingScreen() {
            //if the operation is too short, the _ls is not correctly initialized and it throws 
            //a null error
            if (_ls!=null && _ls.InvokeRequired) {
                _ls.Invoke(new MethodInvoker(CloseLoadingScreen));
            } else {
                if (_shown)
                {
                    //if the operation is too short and the thread is not started
                    //this would close the main thread
                    _shown = false;
                    Application.ExitThread();
                }
                if (_LoadingScreenThread != null)
                    _LoadingScreenThread.Interrupt();
                if (_ls !=null)
                {
                   _ls.Close();
                   _ls.Dispose();
                }
                _LoadingScreenThread = null;
            }
        }
        private static void DoShowLoadingScreen() {
            _ls = new LoadingScreen();
            _ls.FormBorderStyle = FormBorderStyle.None;
            _ls.MinimizeBox = false;
            _ls.ControlBox = false;
            _ls.MaximizeBox = false;
            _ls.TopMost = true;
            //get the parent size
            _ls.Size = _parent.Size; 
            //get the location of the parent in order to show the form over the 
            //target form
            _ls.Location = _parent.Location;     
            //in order to use the size and the location specified above
            //we need to set the start position to "Manual"
            _ls.StartPosition =FormStartPosition.Manual;
            //set the opacity
            _ls.Opacity = 0.5;
            _shown = true;
            //Replaced Application.Run with ShowDialog to show as dialog
            //Application.Run(_ls);
            _ls.ShowDialog();
        }
    }

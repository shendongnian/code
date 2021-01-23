    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            this.PreviewMouseMove += new MouseEventHandler(Window1_PreviewMouseMove);
        }
        void Window1_PreviewMouseMove(object sender, MouseEventArgs e) {
            this.Title = e.GetPosition(this).ToString();
        }
    }

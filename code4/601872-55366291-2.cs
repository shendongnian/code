    public partial class MainWindow : Window
    {
        ....
        // MyMatrixTransform could directly be defined in the xaml file        
        private MatrixTransform MyMatrixTransform = new MatrixTransform();
        public MainWindow()
        {
            InitializeComponent();
            MyMatrixTransform= new MatrixTransform();
            // MyCanvasArea is a canvas defined in the xaml file
            MyCanvasArea.RenderTransform = MyMatrixTransform;
            .....
        }
        // canvas_MouseWheel is attached to canvas in the xaml file as follow
        // <Canvas x:Name="MyCanvasArea" MouseWheel="canvas_MouseWheel" />
        void canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                Matrix matrix = MyMatrixTransform.Matrix;
                matrix.Scale(1.1, 1.1);
                MyMatrixTransform.Matrix = matrix;
            }
            else
            {
                Matrix matrix = MyMatrixTransform.Matrix;
                matrix.Scale(0.9, 0.9);
                MyMatrixTransform.Matrix = matrix;
            }
        }
        ....
    }

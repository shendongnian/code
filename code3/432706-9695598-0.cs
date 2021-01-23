    public class MainForm : Form
    {
        Shape _shape1 = new Shape();
    
        public MainForm()
        {
            InitializeComponent();
            _shape.ShapeNameChanged += HandleShapeNameChanged;
        }
    
        public void HandleShapeNameChanged(object sender, ShapeChangeEventArgs e)
        {
            textBox1.Text = e.NewName;
        }
    }
    
    public class Shape
    {
        public event EventHandler<ShapNameChangedEventArgs> ShapeNameChanged;
    }

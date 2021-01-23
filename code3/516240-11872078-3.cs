    private bool isDragging = false;
    private Point dragOffset = Point.Empty;
    private PictureBox dragBox;
    public Form1() {
      InitializeComponent();
      panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
      panel1.MouseMove += new MouseEventHandler(panel1_MouseMove);
      panel1.MouseUp += new MouseEventHandler(panel1_MouseUp);
      panel1.Paint += new PaintEventHandler(panel1_Paint);
      panel1.DragEnter += new DragEventHandler(panel1_DragEnter);
      panel1.DragDrop += new DragEventHandler(panel1_DragDrop);
    }

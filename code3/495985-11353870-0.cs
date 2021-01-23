    const int N = 6;
    TextBox[,] _matrixATextBoxes = new TextBox[N, N];
    public MyForm() // Form Constructor.
    {
        InitializeComponent();
        SuspendLayout();
        int x = 50; // Horizontal position of first TextBox.
        for (int ix = 0; ix < N; ix++) {
            int y = 80; // Vertical position of first TextBox.
            for (int iy = 0; iy < N; iy++) {
                var tb = new TextBox();
                tb.Location = new Point(x, y);
                tb.Size = new Size(23, 40);
                _matrixATextBoxes[ix, iy] = tb;
                Controls.Add(tb);
                y += 30; // Vertical distance
            }
            x += 50; // Horizontal distance
        }
        ResumeLayout();
    }

    public TestForm()
        {
            InitializeComponent();
            tableLayoutPanel.Paint += tableLayoutPanel_Paint;
        }
    private void tableLayoutPanel_Paint(object sender, PaintEventArgs e){
           e.Graphics.DrawRectangle(new Pen(Color.Blue), e.ClipRectangle);
           
        }

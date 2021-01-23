    public MyUserControl()
    {
         InitializeComponent();
         _PictureBoxes = new List<PictureBox>();
         _PictureBoxesReadOnly = _PictureBoxes.AsReadOnly();
    }

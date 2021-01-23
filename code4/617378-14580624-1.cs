    class MyForm 
    { 
        PictureBox pictureBox1;
        public MyForm()
        {
            ...
            InitializeComponent(); 
            ...
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            ... 
        }
    }

    public Form1()
    {
    InitializeComponent();
    
    PopulatePictures();
    }
    
    private void PopulatePictures()
    {
    this.AutoScroll = true;
    
    string[] list = Directory.GetFiles(@"C:\\Users\\Public\\Pictures\\Sample Pictures", "*.jpg");
    PictureBox[] picturebox= new PictureBox[list.Length];
    int y = 100;
      for (int index = 0; index < picturebox.Length; index++)
      {
      picturebox[index] = new PictureBox();
      this.Controls.Add(picturebox[index]);
      picturebox[index].Location=new Point(index * 120, y);
      if(x%12 == 0)
      y = y + 150;
      picturebox[index].Size = new Size(100,120);
      picturebox[index].Image = Image.FromFile(list[index]);
      }
    }

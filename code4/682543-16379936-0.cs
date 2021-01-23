    public Fullscreenpreview(string filename)
    {
        InitializeComponent();
        this.pictureBox1.MouseMove += this.pictureBox_MouseMove;
        pictureBox1.Image = new Bitmap(filename);
        pictureBox1.Refresh();
        //to show exit button which is a seperate form
        frm3 = new Exitform();
        frm3.FormClosed += (o, e) => this.Close();
        frm3.OnTrackBarValueChanged += new EventHandler(TrackBarValueChanged_Event);
        frm3.Show();
        frm3.TopMost = true;
        //to show exit button which is a seperate form
    }
    
    private void TrackBarValueChanged_Event(Object sender, EventArgs e)
    {
        MessageBox.Show("zoinks the value is = " + frm3.TrackBarValue); 
    }

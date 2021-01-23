	public sbyte contrast
	{
		get { return Exitform.contrastvalue; }
	}
	public Fullscreenpreview(string filename)
	{
		InitializeComponent();
		this.pictureBox1.MouseMove += this.pictureBox_MouseMove;
		pictureBox1.Image = new Bitmap(filename);
		pictureBox1.Refresh();
		//to show exit button which is a separate form
		var frm3 = new Exitform();
		frm3.FormClosed += (o, e) => this.Close();
		frm3.TrackBarMoved += new Action<int>(ChangeContrast);//<< Added
		frm3.Show();
		frm3.TopMost = true;
		//to show exit button which is a separate form
		
		frm3.FormClosed -= (o, e) => this.Close();//<< for memory leaks
		frm3.TrackBarMoved -= new Action<int>(ChangeContrast);//<< for memory leaks
	}
	private void ChangeContrast(int contrastVal)
	{
	    MessageBox.Show("zoinks the value is = " + contrastVal);
	}

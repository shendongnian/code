    //Your form containing the InputBox
    private void Form1_Load(object sender, EventArgs e)
    {
        Label label2 = new Label();
        label2.Text = mesaj;
        label2.Cursor = Cursors.Hand;
    
        label2.Click += OnLabelClick;
    }
    private void OnLabelClick(object sender, EventArgs e)
    {
    	MailController controller = new MailController();
    	controller.SendMail();
    }

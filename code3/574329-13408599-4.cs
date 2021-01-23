    TextBox txtNum = new TextBox();
    public Form1()
    {
    InitializeComponent();
    txtNum.Size = new System.Drawing.Size(578, 20);
    txtNum.Location = new System.Drawing.Point(12, 30);
    txtNum.PreviewKeyDown += (sender, e) =>
    {
        if (e.KeyValue == 17 && e.Control == true)
        {
            MessageBox.Show("you pasted:" + Clipboard.GetText());
        }
    };
    this.Controls.Add(txtNum);
    
    }

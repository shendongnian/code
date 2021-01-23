    private void Form1_Load(object sender, EventArgs e)
    {
        oFont = new Font("Arial", 10);
    
        data = new string[] { "This is Red", "This is Blue", "This is Green", "This is Yellow", "This is Black", "This is Aqua", "This is Brown", "This is Cyan", "This is Gray", "This is Pink" };
        color = new Color[] {Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Black, Color.Aqua, Color.Brown, Color.Cyan, Color.Gray,Color.Pink};
        lstColor.DataSource = data;
        g = Graphics.FromHwnd(lstColor.Handle);
        sf = new StringFormat(StringFormat.GenericTypographic);
    }

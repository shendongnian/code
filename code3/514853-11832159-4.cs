    private void Form1_Load(object sender, EventArgs e)
    {
        oFont = new Font("Arial", 10);
    
        data = new string[] { "This is Red", "This is Blue", "This is Green", "This is Yellow", "This is Black", "This is Aqua", "This is Brown", "This is Cyan", "This is Gray", "This is Pink" };
        color = new Color[] {System.Drawing.Color.Red, System.Drawing.Color.Blue, System.Drawing.Color.Green, System.Drawing.Color.Yellow, System.Drawing.Color.Black, System.Drawing.Color.Aqua, System.Drawing.Color.Brown, System.Drawing.Color.Cyan, System.Drawing.Color.Gray, System.Drawing.Color.Pink};
        lstColor.DataSource = data;
    }

    private void trackBar_Scroll(object sender, System.EventArgs e)
    {
        var trackBar1 = (System.Windows.Forms.TrackBar) sender;
        textBox1.Text = trackBar1.Value.ToString();
    }

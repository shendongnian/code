    void button1_Click(object sender, EventArgs e) {
        string tb1Text = tb1.Text;
        string tb2Text = tb2.Text;
        using(StreamWriter sw = new StreamWriter("myfile.txt")) {
           sw.WriteLine(tb1Text + Environment.NewLine + tb2Text);
        }
    }

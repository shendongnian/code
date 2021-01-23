    protected void btnRead_Click(object sender, EventArgs e)
    {
        string fileText;
        using (StreamReader sr = new StreamReader(Server.MapPath("hello.csv")))
        {
            fileText = sr.ReadToEnd();
            tb1.Text = fileText;
            sr.Dispose();
        }
    }
    protected void btnWrite_Click(object sender, EventArgs e)
    {
        StreamWriter sw = new StreamWriter(Server.MapPath("hello.csv"));
        sw.Write(tb1.Text);
        sw.Dispose();
    }

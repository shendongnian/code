    private void button1_Click(object sender, EventArgs e)
    {
    System.Collections.IEnumerator myEnumerator = Application.OpenForms.GetEnumerator();
    while (myEnumerator.MoveNext())
    {
        Form current = (Form)myEnumerator.Current;
        if (current.WindowState == FormWindowState.Minimized)
        {
            current.WindowState = FormWindowState.Normal;
            current.Activate();
            Application.DoEvents();
            SaveToFile(current); 
            current.WindowState = FormWindowState.Minimized;
            Application.DoEvents();
        }
        else
        {
            current.Activate();           
            Application.DoEvents();                
            SaveToFile(current); 
        }
    }
    }
    private void SaveToFile(Form form)
    {
        using (var bmp = new Bitmap(form.Width, form.Height))
        {
            form.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save(@"c:\temp\childwindows\" + form.Text + ".png");
        }
    }

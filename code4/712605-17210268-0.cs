    private void button1_Click(object sender, EventArgs e)
    {
        //MessageBox.Show(string.Format("{0}", Application.OpenForms.Count));
        System.Collections.IEnumerator myEnumerator = Application.OpenForms.GetEnumerator();
        while (myEnumerator.MoveNext())
        {
            Form current = (Form)myEnumerator.Current;
            if (current.WindowState == FormWindowState.Minimized )
            {
                current.WindowState = FormWindowState.Normal;
                current.Activate();
                Application.DoEvents();
                using (var bmp = new Bitmap(current.Width, current.Height))
                {
                    current.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    bmp.Save(@"c:\temp\childwindows\" + current.Text + ".png");
                }  
            }
        }
    }

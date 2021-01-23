    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        //Create bitmap
        Bitmap image = new Bitmap(dataGridView1.Width, dataGridView1.Height);
        //Create form
        Form f = new Form();
        //add datagridview to the form
        f.Controls.Add(dataGridView1);
        //set the size of the form to the size of the datagridview
        f.Size = dataGridView1.Size;
        //draw the datagridview to the bitmap
        dataGridView1.DrawToBitmap(image, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
        //dispose the form
        f.Dispose();
        //print
        e.Graphics.DrawImage(image, 0, 0);
    }

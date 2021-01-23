     protected void btnRender_Click(object sender, EventArgs e)
    {
        using (StreamReader viewer = new StreamReader((Stream)file1.PostedFile.InputStream))
        {
            TableRow tr;
            TableCell tc;
            while (viewer.Peek() > 0)
            {
                string txtskip = viewer.ReadLine();
                //   Table1.InnerHtml += txtskip; //Table1 is the table i'm wanting to put the results in on my .aspx
                tr = new TableRow();
                tc = new TableCell();
                tr.Cells.Add(tc);
                Table1.Rows.Add(tr);
                tc.Text = txtskip;
            }
        }
    }

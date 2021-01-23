    void dataGridView1_MouseClick(object sender, MouseEventArgs e)
     {
       if (e.Button == MouseButtons.Right)
         {
           int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
           if (currentMouseOverRow >= 0)
             {
               a.Items.Add(string.Format("", currentMouseOverRow.ToString()));
             }
           a.Show(dataGridView1, new Point(e.X, e.Y));
         }
     }

    public class Form1
    {
        public void BuildDataTable()
        {
            DataTable dt = new DataTable("Customers");  
            dt.Columns.Add(new DataColumn("LastName")); 
            dt.Columns.Add(new DataColumn("FirstName")); 
            // Populate the table 
            dt.Rows.Add("Baggins", "Bilbo");
        }
        private void Button2_Click(System.Object sender, System.EventArgs e)
        {
            PrintDocument1.Print();
        }
        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
             Bitmap bm = new Bitmap(this.DataGridView1.Width, this.DataGridView1.Height);
             DataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.DataGridView1.Width, this.DataGridView1.Height));
             e.Graphics.DrawImage(bm, 0, 0);
        }
    }

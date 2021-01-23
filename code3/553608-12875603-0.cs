    namespace Hotel
    {
        public partial class Billing : Form
        {
            SqlConnection con = new SqlConnection();
            SqlDataAdapter da;
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            public Billing()
            {
                InitializeComponent();
            }
    
            private void Billing_Load(object sender, EventArgs e)
            {
                con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\Projects\\c# assignments\\Hotel Manager\\Hotel\\database\\master.mdf;Integrated Security=True;User Instance=True";
                //loadData();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\Projects\\c# assignments\\Hotel Manager\\Hotel\\database\\master.mdf;Integrated Security=True;User Instance=True";
                con.Open();
                int rno = Int32.Parse(txtRoom.Text);
    
                cmd.Connection = con; // This solves the problem you see
                // HERE you SHOULD use a SQL paramter instead of appending strings to build your SQL !!!
                cmd.CommandText = "SELECT SUM(ItemRate) FROM logs WHERE RoomNo=" + rno +"";
                int amt = (int)cmd.ExecuteScalar();   //arror is at this part
    
    
                // HERE you SHOULD use a SQL paramter instead of appending strings to build your SQL !!!
                // Another point: you build an INSERT but never execute it ?!?
                cmd.CommandText = "INSERT INTO bill VALUES('" + txtBillNo.Text.ToString() + "','" + txtRoom.Text.ToString() + "','" + amt.ToString() + "')";
                con.Close();
                txtBillNo.Text = "";
                txtRoom.Text = "";
                BillView bv = new BillView();
                bv.ShowDialog();
            }
        }
    }

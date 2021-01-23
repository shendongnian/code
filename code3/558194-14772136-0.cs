     namespace WindowsFormsApplication1
     {
         public partial class Form1 : Form
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Dataset;Integrated Security=True");
            SqlDataAdapter ds1 = new SqlDataAdapter();
            BindingSource bd = new BindingSource();
            public Form1()
            {
                InitializeComponent();
            }
           private void btnAdd_Click(object sender, EventArgs e)
          {
            ds1.InsertCommand = new SqlCommand("INSERT INTO Employee VALUES(@FirstName,@LastName)", con);
            ds1.InsertCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
            ds1.InsertCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text;
            con.Open();
            ds1.InsertCommand.ExecuteNonQuery();
            con.Close();
        }
        private void btndisplay_Click(object sender, EventArgs e)
        {
            ds1.SelectCommand = new SqlCommand("Select * from Employee", con);
            ds.Clear();
            ds1.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bd.DataSource = ds.Tables[0];
            //txtFirstName.DataBindings.Add("Text", bd, "FirstName");
            //txtLastName.DataBindings.Add("Text", bd, "LastName");
        }
        private void btnPervious_Click(object sender, EventArgs e)
        {
            bd.MovePrevious();
            update();
            records();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            bd.MoveNext();
            update();
            records();
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            bd.MoveFirst();
            update();
            records();
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            bd.MoveLast();
            update();
            records();
        }
        private void update()
        {
            dataGridView1.ClearSelection();
            dataGridView1.Rows[bd.Position].Selected = true;
            records();
        }
        private void records()
        {
            label1.Text = "records" + bd.Position + " of " + (bd.Count - 1);
            
        }

            view.RowFilter = "LastName like '%" + textBox1.Text + "%'";
            if (textBox1.Text == "") view.RowFilter = string.Empty;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable datatable = new DataTable();
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Mattias\Dropbox\C#\Database\Baseball.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            datatable.Load(new SqlCommand("select * from players", connection).ExecuteReader());
            dataGridView1.DataSource = view = datatable.DefaultView;
            connection.Close();
        }

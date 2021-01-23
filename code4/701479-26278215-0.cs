            flowLayoutPanel1.Controls.Clear();
            SqlConnection cn = new SqlConnection(@"server=.;database=MyDatabase;integrated security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from Items order by ItemsName", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Button btn = new Button();
                btn.Name = "btn" + dt.Rows[i][1];
                btn.Tag = dt.Rows[i][1];
                btn.Text = dt.Rows[i][2].ToString();
                btn.Font = new Font("Arial", 14f, FontStyle.Bold);
                // btn.UseCompatibleTextRendering = true;
                btn.BackColor = Color.Green;
                btn.Height = 57;
                btn.Width = 116;
                btn.Click += button1_Click;   //  set any method
                btn.Enter += button1_Enter;   // 
                btn.Leave += button1_Leave;   //
                
                
                flowLayoutPanel1.Controls.Add(btn);                
            }
        

                 private void Form3_Load(object sender, EventArgs e)
                  {
                      using (SqlConnection sc = new SqlConnection())
                       {
                        sc.ConnectionString= "database=KnowledgeEssentials;Trusted_Connection=yes;connection timeout=30";
                        sc.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                         {
                           DataTable data = new DataTable();
                           sda.SelectCommand = new SqlCommand("SELECT ID, TypeProblem FROM eL_Section", sc);
                           sda.Fill(data);
                           comboBox1.ValueMember = "ID";
                           comboBox1.DisplayMember = "ID";
                           comboBox1.DataSource = data;
                           comboBox2.ValueMember = "TypeProblem";
                           comboBox2.DisplayMember = "TypeProblem";
                           comboBox2.DataSource = data;
                         }
                 }
                using (SqlConnection cn = new SqlConnection())
                  {
                cn.ConnectionString = "database=KnowledgeEssentials;Trusted_Connection=yes;connection timeout=30";
                cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter())
                      {
                        DataTable dat = new DataTable();
                        da.SelectCommand = new SqlCommand("SELECT UserName FROM UserT", cn);
                        da.Fill(dat);
                    
                    
                        comboBox3.ValueMember = "UserName";
                        comboBox3.DisplayMember = "UserName";
                        comboBox3.DataSource = dat;
                      }
                  }
            // TODO: This line of code loads data into the 'knowledgeEssentialsDataSet.ProblemT' table. You can move, or remove it, as needed.
            this.problemTTableAdapter.Fill(this.knowledgeEssentialsDataSet.ProblemT);
         }

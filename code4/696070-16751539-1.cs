    private void button1_Click(object sender, EventArgs e)
        {            
            OpenFileDialog thisDialog = new OpenFileDialog();
            DataTable dt = new DataTable();
            DataRow dr = null;
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;
            progressBar1.Visible = true;
    
            if (thisDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text=thisDialog.FileName;
                string file1 = textBox1.Text;
                progressBar1.Maximum = File.ReadAllLines(file1).Length;
                using (System.IO.StreamReader file = new System.IO.StreamReader(file1))
                {           
                    string line=String.Empty;
                    int lineno = 0;                    
    
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains("DISKXFER"))
                        {
                            string dataLine = line.ToString();
                            string[] split = dataLine.Split(',');
                            int result = split.Length;
                            if (lineno == 0)
                            {
                                for (int x = 0; x < result; x++)
                                {
                                    DataColumn dcss = new DataColumn(x.ToString(), Type.GetType("System.String"));
                                    dt.Columns.Add(dcss);
                                }
                                if (dt.Rows.Count <= lineno)
                                {
                                    dr = dt.NewRow();
                                    dt.Rows.Add(dr);                                    
                                }
                                dr = dt.Rows[lineno];                                
                                for (int x = 0; x < result; x++)
                                {
                                    dr[x+1] = split[x];
                                }                                
                            }                                
                            else
                            {
                                if (dt.Rows.Count <= lineno)
                                {
                                    dr = dt.NewRow();
                                    dt.Rows.Add(dr);                                    
                                }
                                dr = dt.Rows[lineno];                               
                                for (int x = 0; x < result; x++)
                                {
                                    dr[x+1] = split[x];
                                }
    
                            }
                            progressBar1.Value = dt.Rows.IndexOf(dr);
                            Application.DoEvents();
                            lineno += 1;                        
    
                        }
    
                    }
    
                }
            }
    
            dataGridView1.DataSource = dt;
        }  

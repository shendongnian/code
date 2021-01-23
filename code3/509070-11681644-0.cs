            DataGridViewButtonColumn buttonCol = new DataGridViewButtonColumn();
            public Form1()
            {
                InitializeComponent();
                
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = "Dosage";
                col.Width = 80;
                int colIndex = dataGridView1.Columns.Add(col);
    
                DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
                col2.HeaderText = "Drug";
                col2.Width = 75;
                colIndex = dataGridView1.Columns.Add(col2);
    
                DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
                col3.HeaderText = "Patient";
                col3.Width = 75;
                colIndex = dataGridView1.Columns.Add(col3);
    
                DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
                col4.HeaderText = "Date";
                col4.Width = 40;
                colIndex = dataGridView1.Columns.Add(col4);
    
            
                buttonCol.Name = "btnNotes";
                buttonCol.HeaderText = "Notes";
                buttonCol.Text = "Notes";
                buttonCol.Width = 80;
                buttonCol.UseColumnTextForButtonValue = true;
                buttonCol.DefaultCellStyle.Font = new Font("Arial", 12);
                dataGridView1.Columns.Add(buttonCol);
    
                timer1.Start();
                timer1.Tick += new EventHandler(timer1_Tick);
    
                
            }
    
            void timer1_Tick(object sender, EventArgs e)
            {
                int i = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null || row.Cells[3].Value == null)
                    {
                        dataGridView1.Rows[i].Cells[4].Style.Font = new Font(dataGridView1.Font, FontStyle.Regular);
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[4].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    }
                    i++;
                }
            }
    
    
    
            static DataTable GetTable()
            {
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("BlaBlaBla", typeof(string));
    
            table.Rows.Add(25, "Indocin", "David", "Notes in here");
            table.Rows.Add(50, "Enebrel", "Sam", "");
            table.Rows.Add(10, "Hydralazine", "Christoff", "");
            table.Rows.Add(21, "Combivent", "Janet", "Notes in here");
            table.Rows.Add(100, "Dilantin", "Melanie", "");
    
            return table;
            }

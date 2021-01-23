    using (SqlConnection c = new SqlConnection("Server=localhost;Database=deno;Trusted_Connection=True;"))
                {
                    c.Open();
    
                    using (SqlDataAdapter a = new SqlDataAdapter(
                        "SELECT * FROM test", c))
                    {
                        // 3
                        // Use DataAdapter to fill DataTable
                        string dm = "TestScroll";
                        DataSet ds = new DataSet();
                        a.Fill(ds, dm);
                        // 4
                        // Render data onto the screen
                        m_dView.AllowUserToAddRows = false;
                        m_dView.DataSource = ds;
                        m_dView.DataMember = dm;
                        m_dView.AutoGenerateColumns = true;
                        m_dView.MultiSelect = false;
                        m_dView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        m_dView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        m_dView.ReadOnly = true;
                        m_dView.AllowUserToAddRows = false;
                        m_dView.AllowUserToDeleteRows = false;
                        m_dView.AllowUserToOrderColumns = false;
                        m_dView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        m_dView.AllowUserToResizeColumns = false;
                        m_dView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                        m_dView.AllowUserToResizeRows = false;
                        m_dView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
    
                    }
                    m_dView.FirstDisplayedScrollingRowIndex = m_dView.Rows.Count-1;
                }

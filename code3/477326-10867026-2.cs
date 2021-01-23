    /// <summary>
      /// when this method called, it sets visible = false the columns where not in List of column names
      /// The column names List count and header List count must be the same number
      /// </summary>
      /// <param name="dgvName">DGV which calls this ext method</param>
      /// <param name="Method">the data source load method of the DGV which calls this ext method</param>
      /// <param name="ColumnName">The columnNames List which contains the columns will show.. columnName List's type is List<string></param>
      /// <param name="Header">The list where you can set the dgv's headers as you prefer..it's type is also List<string></param>
      /// <returns></returns>
      public static DataGridView showTheGivenColumns(this DataGridView dgvName, object dataSourceLoadMethod, List<string> columnNameList, List<string> headerList)
                {
                    dgvName.DataSource = null;
                    dgvName.Columns.Clear();
                    dgvName.DataSource = dataSourceLoadMethod;
                    int j = columnNameList.Count;
                    int m = 0;
                    int s = headerList.Count;
    
                    if (j == s)
                    {
    
                        foreach (DataGridViewColumn d in dgvName.Columns)
                        {
                            for (int i = 0; i < j; i++)
                            {
                                if (d.Name == columnNameList[i])
                                {
                                    d.HeaderText = headerList[i];
                                    d.Visible = true;
                                    d.Width = d.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, false);
                                    
                                    m += d.Width;
                                    break;
                                }
                                else
                                {
                                    d.Visible = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Count of Header and ColumnName Lists are not equal..Please Check.");
                    }

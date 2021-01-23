          string data = String.Empty;
          for (int col = 0; col < datagridview.ColumnCount; col++)
          {
              data += Convert.ToString(datagridview.Columns[col].HeaderText);
          }
          data += "\n";
          for (int i = 0; i < datagridview.RowCount; i++)
            {
                for (int j = 0; j < datagridview.ColumnCount; j++)
                {
                    data += Convert.ToString(datagridview.Rows[i].Cells[j].Value);
                    data += "\t";
                }
                data += "\n";
            }
            StreamWriter SW;
            SW = File.AppendText(@"C:\File.txt");
            
            SW.WriteLine(data + Environment.NewLine);
            SW.Close();

        StringWriter stringWriter1 = new StringWriter();
        DataTable dataTable1 = new DataTable();
        private void Form1_Shown(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            int i;
            for (i = 0; i < 10; i++)
            {
                dataTable1.Columns.Add("Column" + (i + 1), typeof(string));
            }
            for (i = 0; i < 10; i++)
            {
                DataRow dataRow1 = dataTable1.NewRow();
                dataTable1.Rows.Add(dataRow1);
            }
            dataGridView1.DataSource = dataTable1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string rowString = "";
            int i,j;
            for (i = 0; i < 10; i++)
            {
                rowString = "";
                for (j = 0; j < 10; j++)
                {
                    if (dataTable1.Rows[i][j].ToString().Contains(",") == true)
                    {
                        //Enclosing the field data inside quotes so that it can
                        //be identified as a single entity.
                        rowString += "\"" + dataTable1.Rows[i][j] + "\"" + ",";
                    }
                    else
                    {
                        rowString += dataTable1.Rows[i][j] + ",";
                    }
                }
                rowString = rowString.Substring(0, rowString.Length - 1);
                stringWriter1.WriteLine(rowString);
            }
        }

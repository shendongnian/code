            if (e.ColumnIndex == 1)
            {
                try
                {
                    string val = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (val == "False")
                        val = "True";
                    else if (val == "True")
                        val = "False";
                    dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = val;
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        string active = "";
                        if (i != e.RowIndex)
                        {
                            if (val == "False")
                            {
                                dataGridView3.Rows[i].Cells[1].Value = "True";
                                active = "Y";
                            }
                            else if (val == "True")
                            {
                                dataGridView3.Rows[i].Cells[1].Value = "False";
                                active = "N";
                            }
                        }
                        else
                        {
                            if (val == "False")
                                active = "N";
                            else
                                active = "Y";
                        }
                    }
                }
                catch (Exception ex)
                { }
            }
        }

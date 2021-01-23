    List<int> list1 = new List<int>() { 1, 2, 3, 4 };
                List<string> list2 = new List<string>() { "a", "b", "c", "d", "e" };
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AutoGenerateColumns = false;
                int myRow = -1;
                int myCell = -1;
                foreach (var i in list1)
                {
                    myRow = myRow + 1;
                    foreach (var d in list2)
                    {
                        myCell = myCell + 1;
                        if(dataGridView1.Rows.Count==1)
                            dataGridView1.Rows.Add(list1.Count);
                        dataGridView1.Rows[myRow].Cells[myCell].Value = i + "and" + d;
                    }
                    myCell = -1;
                }

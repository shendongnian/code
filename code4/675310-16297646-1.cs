    private void button5_Click(object sender, EventArgs e) //Writes to date where names are selected.
        {
            ApplicationClass msProj = new ApplicationClass();
            int i = 0;
            foreach (Task t in msProj.ActiveProject.Tasks)
            {
                if (i < checkedListBox1.CheckedItems.Count)
                {
                    if (t.ID == int.Parse(checkedListBox1.CheckedItems[i].ToString()))
                    {
                        t.Start = DateTime.Parse(dateTimePicker1.Text);
                        i++;
                    }
                }
            }
        }

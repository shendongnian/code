    hook the **DataBindingComplete** event and do stuff in it:
         private void dataGridView1_DataBindingComplete(object sender, 
                           DataGridViewBindingCompleteEventArgs e)
        {
            if (e.ListChangedType != ListChangedType.ItemDeleted)
            {
                DataGridViewCellStyle red = dataGridView1.DefaultCellStyle.Clone();
                red.BackColor=Color.Red;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (r.Cells["FollowedUp"].Value.ToString()
                           .ToUpper().Contains("NO"))
                    {
                        r.DefaultCellStyle = red;
                    }
                }
            }
        }

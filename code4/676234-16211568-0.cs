    private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
                int max=0;
                for(int i=0;i<dataGridViewOwner.Rows.Count;i++)
                  if(dataGridViewOwner.Rows[i].Cells[0].Value!=null && dataGridViewOwner.Rows[i].Cells[0].Value!=DBNull.Value )
                  {
                      try
                       {
                             int pre= int.Parse(dataGridViewOwner.Rows[i].Cells[0].Value.ToString());
                            if(pre>max)
                                  max=pre;
                       }
                      catch
                     {
                       }
                  }//if
                 max++;
                dataGridViewOwner.CurrentRow.Cells[0].Value=max;//if assume crrent row is target new row
        }

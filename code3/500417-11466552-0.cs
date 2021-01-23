    void grd_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
          if ((sender as DataGridView).CurrentCell is DataGridViewCheckBoxCell)
          {
               if (Convert.ToBoolean(((sender as DataGridView).CurrentCell as DataGridViewCheckBoxCell).Value))
               {
                       // Maybe have a method which does the
                        //loop and set value except for the current cell
                }
            }
    }

    public List<int> selectedIndexes = new List<int>();
    
    private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
    {
         if (e.StateChanged == DataGridViewElementStates.Selected)
         {
              //selected
              if (e.Row.Selected)
              { 
                  int newRowIndex = e.Row.Index;
                        
                  //if other rows selected make sure adjacent selection exists                   
                  if (selectedIndexes.Count() > 0)
                  {
                      if (selectedIndexes.Contains(newRowIndex - 1) || selectedIndexes.Contains(newRowIndex + 1))
                      {
                                //allow selection
                            selectedIndexes.Add(newRowIndex);
                      }
                      else
                      {
                            //cancel selection
                            e.Row.Selected = false;
                      }
                   }
                   else
                   {
                       //first selection so allow it
                        selectedIndexes.Add(newRowIndex);
                    }
               }
               else if( !e.Row.Selected)
               {
                       //row deselected (need to add logic to remove non adjacent rows to be unselected as well)
                        selectedIndexes.Remove(e.Row.Index);
               }
         }
   }

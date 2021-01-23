            private void gridContacts_CellValueNeeded(object sender,  DataGridViewCellValueEventArgs e)
            {
               ResultRow dataObject = resultRows[e.RowIndex];
               switch(e.ColumnIndex)
               {
                   case 0:
                       e.Value = dataObject.First;
                       break;
                   case 1 :
                       e.Value = dataObject.Second;
                       break;
                   //etc..
               }
            }

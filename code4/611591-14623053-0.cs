            void myMasterTableBindingSource_CurrentChanged(object sender, EventArgs e)
        {
                DataRowView selectedRow = myMasterTableBindingSource.Current as DataRowView;
                if (selectedRow != null && !selectedRow.IsNew)
                { 
                    this.myChildTableTableAdapter.FillByUser(this.myDataSet.MyChildTable, (int)selectedRow["UserID"]);
                }
          
        }
  

    System.Windows.Threading.DispatcherTimer timMakeEditable = new System.Windows.Threading.DispatcherTimer();
      private void dataGridView1_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
    {
        timMakeEditable.Interval = new TimeSpan(0, 0, 0, 0, 100); // 100 Milliseconds 
        timMakeEditable.Tick += new EventHandler(timer_Tick);
        timMakeEditable.Start();
        if (e.RowIndex == r && e.ColumnIndex == c)
        {
                dataGrid1.Columns[yourColumnIndex].IsReadOnly = true;     
        }
    }

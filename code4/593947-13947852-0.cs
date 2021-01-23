        public void Excel_OlaylariTanimla()
        {
          try
            {
              EventDel_SelChange = new Excel.DocEvents_SelectionChangeEventHandler(SelChange);
              oSheet.SelectionChange += EventDel_SelChange;
    //        EventDel_CellsChange = new Excel.DocEvents_ChangeEventHandler(CellsChange);
    //        oSheet.Change += EventDel_CellsChange;
            }
          catch (Exception ex)
            {
                    throw;
            }
        }
    
      private void SelChange(Excel.Range Target)
        {    
          MessageBox.Show("Selection Changed");
          eventtrigger++;
          MessageBox.Show(eventtrigger.ToString());
        }

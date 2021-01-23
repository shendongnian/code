     public static void ReturnExtendedPartProperties(MainWindowVM mainWindowVM)
      {
           mainWindow.ReturnAttsPerPn_Result = new ObservableCollection<ReturnAttsPerPn_Result>();
           using (var myEntities = new MyEntities())
           {
                 var results = myEntities.ReturnAttsPerPn(mainWindowVM.SelectedPart.PnID)
                 if (mainWindowVM.SelectedPart != null)
                 {
                      mainWindowVM.ReturnAttsPerPn_Result.Clear();
                      foreach (ReturnAttsPerPn_Result attresult in results)
                      {
                            mainWindowVM.ReturnAttsPerPn_Result.Add(attresult);
                      }
                  } 
           }
     }

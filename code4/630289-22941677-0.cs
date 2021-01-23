    const string tempoarySheetSetSettingName = "Temp Sheet Set";
    
    ViewSheetSetting viewSheetSetting = _printManager.ViewSheetSetting;
    
    //Save your temporary sheet set
    _printManager.ViewSheetSetting.SaveAs(tempoarySheetSetSettingName);
    
    ViewSheetSet selected = null;
    
    FilteredElementCollector viewCollector = new FilteredElementCollector(document);
    viewCollector.OfClass(typeof(ViewSheetSet));
    
    //Find the sheet set that you just created
    foreach (ViewSheetSet set in viewCollector.ToElements())
    {
      if (String.Compare(set.Name, tempoarySheetSetSettingName) == 0)
      {
    	selected = set;
    	break;
      }
    }
    
    //Set the current view sheet set to the one that you just created
    viewSheetSetting.CurrentViewSheetSet = selected;
    
    //Set the views to which ever set you would like to print
    viewSheetSetting.CurrentViewSheetSet.Views = viewSetToPrint;
    viewSheetSetting.Save();

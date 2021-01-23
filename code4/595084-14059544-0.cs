    public class myStatesCombo : ComboBox
    {
       public myStatesCombo()
       {
          Loaded += myAfterLoaded;
       }
    
       protected static DataTable myTableOfStates;
    
       public void myAfterLoaded()
       {
          if( myTableOfStates == null )
            myTableOfStates = new DataTable();
          CallProcedureToPopulateStates( myTableOfStates );
    
          ItemsSource = myTableOfStates.DefaultView;
          // AFTER the object is created, and all default styles attempted to be set,
          // FORCE looking for the resource of the "DataTemplate" in the themes.xaml file
          object tryFindObj = TryFindResource("myStateComboTemplate" );
          if( tryFindObj is DataTemplate )
             ItemTemplate = (DataTemplate)tryFindObj;
    
          // NOW, the CRITICAL component missed in the source code
          TextSearch.SetTextPath( this, "StateAbbrev" );
       }
    }

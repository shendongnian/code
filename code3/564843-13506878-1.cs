      /// <summary>
      /// -MyExtndDataGrid an extension of datagrid
      /// </summary>
      public class MyExtndDataGrid : DataGrid
      {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override AutomationPeer OnCreateAutomationPeer()
        {
          return null;
        }
      }
    
    and in the XAML
    
     <local:MyExtndDataGrid ...../>
    
    

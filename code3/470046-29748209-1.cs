    		public void Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector Inspector)
        {
			Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane;
            
			if(Inspector.CurrentItem is  Microsoft.Office.Interop.Outlook.AppointmentItem ) {
			
				UserControl uc1 = MyUserControl();
				myCustomTaskPane = getAddIn().CustomTaskPanes.Add(uc1, "MyPanel",Inspector);
				myCustomTaskPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
				myCustomTaskPane.DockPositionRestrict = Office.MsoCTPDockPositionRestrict.msoCTPDockPositionRestrictNoChange;
				myCustomTaskPane.Visible = true;
			
			}
			
			//Additionally You can add a property change listener to the current Item here
        }

    	public class yourclass
	{
	public Document AcDoc {
		get { return AcApp.DocumentManager.MdiActiveDocument;}
	}
	
        public static SelectionSet getSelectionSet()
		{
			var _editor = AcDoc.Editor;
			var _selAll = ed.SelectAll();
			return _selAll.Value;
		}
	}

    using AcApp = Autodesk.Autocad.ApplicationServices.Application;
    
    public class yourclass 
    {
      public Document AcDoc {
			get { return AcApp.DocumentManager.MdiActiveDocument;} 
		}     
      public static void getSelectionSet()
      {
        var _editor = AcDoc.Editor;
        var _selAll = ed.SelectAll();
	    var _SelectionSet = _selAll.Value;
		
	    using(var trans = AcDoc.TransactionManager.StartTransaction()){
	      foreach(var ObjId in _SelectionSet.GetObjectIds()){
		    // apply logic
	      }
          trans.Commit();
        } 
      }
    

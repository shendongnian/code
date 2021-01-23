        using Autodesk.AutoCAD.ApplicationServices;
        using Autodesk.AutoCAD.DatabaseServices;
        using Autodesk.AutoCAD.Runtime;
        using AcApplication = Autodesk.AutoCAD.ApplicationServices.Application;
        public static Document acDoc {
			get {
				return Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
			}
		}
        public static MText getMTextObj(string TextYouNeed)
		{
			var ed = acDoc.Editor;
			var selMText = new TypedValue[1];
			selMText.SetValue(new TypedValue(0,"MTEXT"),0);
			var MTextObjs = ed.SelectAll(new SelectionFilter(selMText));
		
			using (var Transaction = AcApplication.DocumentManager.MdiActiveDocument.Database.TransactionManager.StartTransaction()) {
				foreach (ObjectId MTextObjId in MTextObjs.Value.GetObjectIds()) {
					var current_MTextObj = Transaction.GetObject(MTextObjId,OpenMode.ForRead) as MText;
					if(current_MTextObj.Text.Equals(TextYouNeed))
						// return current_MTextObj;
						// or
						// do somehting else 
				}
			}
            Transaction.Commit(); // if you change something.
		}

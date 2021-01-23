    using System;
    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    namespace stackclass
    {
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class MyClass : BlockTableRecord
	{
		public string BlkRecordName {get;set;}
		
		public MyClass(BlockTableRecord _RecordParam)
		{
			BlkRecordName = _RecordParam.Name;
		}
		
		public MyClass(){}
	}
	
    public static class MyClassInstanciator 
	{
		public static void Main(string[] args) 
		{
			var AcDoc = Application.DocumentManager.MdiActiveDocument;
			using (var Trans = Application.DocumentManager.MdiActiveDocument.TransactionManager.StartTransaction()) {
				
				var BlkTable = Trans.GetObject(AcDoc.Database.BlockTableId,OpenMode.ForRead) as BlockTable;
				foreach (var BlkRcrdId in BlkTable) {
					var _blkRcrd = Trans.GetObject(BlkRcrdId,OpenMode.ForRead) as BlockTableRecord;
					var MyClassRcd = new MyClass(_blkRcrd);
					// or
					var _MyClassRcd = new MyClass();
					_MyClassRcd.BlkRecordName = _blkRcrd.Name;
				}
			}
		}
	}
    

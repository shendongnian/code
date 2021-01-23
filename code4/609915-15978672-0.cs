    using Autodesk.AutoCAD.ApplicationServices;
    using App = Autodesk.AutoCAD.ApplicationServices.Application;
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.EditorInput;
    Document curDoc = App.DocumentManager.MdiActiveDocument;
    Extents3d allEntsExtents = new Extents3d();
    using (Transaction tr = curDoc.TransactionManager.StartTransaction())
    {
        BlockTable bt = tr.GetObject(curDoc.Database.BlockTableId, OpenMode.ForRead, false) as BlockTable;
        BlockTableRecord btr = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead, false) as BlockTableRecord;
        allEntsExtents.AddBlockExtents(btr);
        tr.Commit();
    }
    Plane plane = new Plane();
    Extents2d window = new Extents2d(
        allEntsExtents.MinPoint.Convert2d(plane),
        allEntsExtents.MaxPoint.Convert2d(plane));

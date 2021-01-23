    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.Runtime;
     
    [CommandMethod("SendACommandToAutoCAD")]
    public static void selectEntireAutoCadDrawing()
    {
      //This sets up your doc. Not sure if this is the way you're doing it.
      //I imagine you'd probably pass the doc into the method.
      Document yourACDoc = Application.DocumentManager.MdiActiveDocument;
      
      //When your plug-in is invoked the first thing I'd do is make sure they're
      //in PaperSpace
      yourACDoc.SendStringToExecute("tilemode 0 ");
      //Next enable ModelSpace through PaperSpace.
      yourACDoc.SendStringToExecute("_mspace ");
      //Now we zoom to the extents of the drawing.
      //Not sure about the bools at the end. The AC documentation has it there for a
      //zoom all example but AC doesn't ask any further questions after selecting the 
      //all or extents zoom types?
      yourACDoc.SendStringToExecute("._zoom _extents "/*, true, false, false*/);
    }

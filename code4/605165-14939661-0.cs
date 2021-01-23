    Microsoft.Office.Interop.MSProject.Application app = new Microsoft.Office.Interop.MSProject.Application();
    app.DisplayAlerts = false;
    app.AskToUpdateLinks = false;
    app.FileOpenEx(
            Server.MapPath("") + "\\sample.mpx",
            false,
            Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,
            PjPoolOpen.pjPoolReadWrite, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
             Microsoft.Office.Interop.MSProject.Project pj=app.ActiveProject;
    app.CalculateAll(); //Para calcular las fechas
    app.FileSaveAs(Server.MapPath("") + "\\sample.mpp",PjFileFormat.pjMPP, Type.Missing, Type.Missing,Type.Missing,           Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing);

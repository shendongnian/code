       private static void InsertStencilsToVisio()
       {   visioApplication = new Application();
            string fileName = @"C:\siva\CreateGen1Visio\pd-m-0001_1.11.vdw";
            string stencilFileName = @"C:\siva\CreateGen1Visio\eswstencil.vss";
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    visioDocument = visioApplication.Documents.OpenEx(fileName, (short)Microsoft.Office.Interop.Visio.VisOpenSaveArgs.visOpenDontList);
                    visioPage = visioDocument.Application.ActivePage;
                    visioPage.Application.Documents.OpenEx(stencilFileName, (short)Microsoft.Office.Interop.Visio.VisOpenSaveArgs.visOpenDocked);
                    visioDocument.SaveAsEx(fileName, (short)Microsoft.Office.Interop.Visio.VisOpenSaveArgs.visSaveAsWS);
                }
            }
       }

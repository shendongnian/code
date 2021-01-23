            private static bool BuildPDF(string pdfPath)
        {
            bool pdfBuilt = false;
            try
            {
                var theDoc = new Doc();
                string pdGeneral = "http://ww.myurl.com";
                theDoc = CreateNewDoument(pdGeneral);
                theDoc = AddFooter(theDoc);
                theDoc.Save(pdfPath);
                theDoc.ClearCachedDecompressedStreams();
                theDoc.Clear();
                theDoc.Dispose();
                pdfBuilt = true;
            }
            catch (Exception)
            {
                //PDF normaly in use dont worry..
            }
            return pdfBuilt;
        }

                [CommandMethod("CD", CommandFlags.Session)]
                static public void CloseDocuments()
                {
                    DocumentCollection docs = Application.DocumentManager;
                    foreach (Document doc in docs)
                    {
                        // First cancel any running command
                        if (doc.CommandInProgress != "" &&
                            doc.CommandInProgress != "CD")
                        {
                            AcadDocument oDoc =
                              (AcadDocument)doc.AcadDocument;
                            oDoc.SendCommand("\x03\x03");
                        }
        
                        if (doc.IsReadOnly)
                        {
                            doc.CloseAndDiscard();
                        }
                        else
                        {
                            // Activate the document, so we can check DBMOD
                            if (docs.MdiActiveDocument != doc)
                            {
                                docs.MdiActiveDocument = doc;
                            }
                            int isModified =
                              System.Convert.ToInt32(
                                Application.GetSystemVariable("DBMOD")
                              );
        
                            // No need to save if not modified
                            if (isModified == 0)
                            {
                                doc.CloseAndDiscard();
                            }
                            else
                            {
                                // This may create documents in strange places
                                doc.CloseAndSave(doc.Name);
                            }
                        }
                    }

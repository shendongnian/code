                    foreach (PermStart p1 in wordD.MainDocumentPart.Document.Body.Descendants<PermStart>())
                    {
                        p1.Parent.RemoveChild<PermStart>(p1);
                    }
                    foreach (PermEnd p2 in wordD.MainDocumentPart.Document.Body.Descendants<PermEnd>())
                    {
                        p2.Parent.RemoveChild<PermEnd>(p2);
                    }
                    wordD.MainDocumentPart.Document.Save();

        var file = @"c:\temp\PackageLabels.pdf";
        var doc = PdfReader.Open(file);
        var page = doc.Pages[0];
        {
            // Get resources dictionary
            PdfDictionary resources = page.Elements.GetDictionary("/Resources");
            if (resources != null)
            {
                // Get external objects dictionary
                PdfDictionary xObjects = resources.Elements.GetDictionary("/XObject");
                if (xObjects != null)
                {
                    ICollection<PdfItem> items = xObjects.Elements.Values;
                    // Iterate references to external objects
                    foreach (PdfItem item in items)
                    {
                        PdfReference reference = item as PdfReference;
                        if (reference != null)
                        {
                            PdfDictionary xObject = reference.Value as PdfDictionary;
                            // Is external object an image?
                            if (xObject != null && xObject.Elements.GetString("/Subtype") == "/Image")
                            {
                                // do something with your image here 
                                // only the first image is handled here
                                var bitmap = ExportImage(xObject);
                                bmp.Save(@"c:\temp\exported.png", System.Drawing.Imaging.ImageFormat.Bmp);
                            }
                        }
                    }
                }
            }
        }

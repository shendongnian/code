    	private static void ReplacePdfCreator(PdfWriter writer)
        {
            /*
             
             Warning
             * 
             This is not an option offered as is and i had to workaround it by using Reflection and change it
             manually.
             * 
             Alejandro
             
             */
            Type writerType = writer.GetType();
            PropertyInfo writerProperty =
                writerType.GetProperties(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
                          .FirstOrDefault(p => p.PropertyType == typeof(PdfDocument));
            if (writerProperty != null)
            {
                PdfDocument pd = (PdfDocument)writerProperty.GetValue(writer);
                Type pdType = pd.GetType();
                FieldInfo infoProperty =
                    pdType.GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
                          .FirstOrDefault(p => p.Name == "info");
                if (infoProperty != null)
                {
                    PdfDocument.PdfInfo pdfInfo = (PdfDocument.PdfInfo)infoProperty.GetValue(pd);
                    if (pdfInfo != null)
                    {
                        string creator = pdfInfo.GetAsString(new PdfName("Producer")).ToLowerInvariant();
                        
			if(creator.Contains("itextsharp"))
			{
				// created with itext sharp
			}
			else if(creator.Contains("adobe"))
			{
				// created with adobe something (distiller, photoshop, whatever)
			}
			else if(creator.Contains("pdfpro"))
			{
				// created with pdf pro
			}
			else if(add your own comparison here, for example a scanner manufacturer software like HP's one)
			{
			}
                    }
                }
            }
	}

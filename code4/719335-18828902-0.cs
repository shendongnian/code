                    if (AnnotationDictionary.Get(PdfName.SUBTYPE).Equals(PdfName.TEXT))
                    {
                        string Title = AnnotationDictionary.GetAsString(PdfName.T).ToString();
                        string Content = AnnotationDictionary.GetAsString(PdfName.CONTENTS).ToString();
                    }

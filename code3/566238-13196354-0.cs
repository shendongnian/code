    /// <summary>
            /// Updates the PDF document. From the class that you send it. It will match up any property names to any fields in the PDF.
            /// if no properties are found then it will check the custom attribute PdfFieldName to see if the Name is the same in this attribute.
            /// if so then it will map that property still.
            /// Example: 
            /// PDF Field name: "TextBox Name"
            /// 
            /// [PdfFieldName("TextBox Name")]
            /// public string TextBoxName { get; set; }
            /// 
            /// Since the Property name is TextBoxName it would not be mapped however since the attribute PdfFieldName does match it wil be mapped.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="oldPdfPath">The old PDF path.</param>
            /// <param name="newPdfPath">The new PDF path.</param>
            /// <param name="genericClass">The generic class.</param>
            /// <param name="usePdfFieldNameAttribute"> </param>
            public static void UpdatePdfDocument<T>(string oldPdfPath, string newPdfPath, T genericClass, bool usePdfFieldNameAttribute)
            {
                PdfReader pdfReader = new PdfReader(oldPdfPath);
                using (PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newPdfPath, FileMode.Create)))
                {
                    AcroFields pdfFormFields = pdfStamper.AcroFields;
                    var props = from p in typeof(T).GetProperties()
                                let attr = p.GetCustomAttributes(typeof(PdfFieldName), true)
                                where attr.Length == 1
                                select new { Property = p, Attribute = attr.First() as PdfFieldName };
    
                    PropertyInfo[] properties = typeof(T).GetProperties();
    
                    // set form pdfFormFields
                    foreach (string field in pdfReader.AcroFields.Fields.Select(de => de.Key))
                    {
                        PropertyInfo pi = properties.FirstOrDefault(p => p.Name.ToUpper() == field.ToUpper());
                        if (pi != null)
                            pdfFormFields.SetField(field, pi.GetValue(genericClass, null).ToString());
                        else if (props != null && usePdfFieldNameAttribute)
                        {
                            var result = props.FirstOrDefault(p => p.Attribute.Name.ToUpper() == field.ToUpper());
                            if (result != null)
                            {
                                pi = result.Property;
                                pdfFormFields.SetField(field, pi.GetValue(genericClass, null).ToString());
                            }
                        }
                    }
    
                    // flatten the form to remove editting options, set it to false
                    // to leave the form open to subsequent manual edits
                    pdfStamper.FormFlattening = true;
    
                    // close the pdf
                    pdfStamper.Close();
                    // close the pdfreader
                    pdfReader.Close();
                }
            }

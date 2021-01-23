    public static string XDocToStringWithDeclaration(XDocument doc)
            {
                string xString;
                using (var sw = new System.IO.MemoryStream())
                {
                    using (var strw = new System.IO.StreamWriter(sw, System.Text.UTF8Encoding.UTF8))
                    {
                        doc.Save(strw);
                        xString = System.Text.UTF8Encoding.UTF8.GetString(sw.ToArray());
                    }
                }
                return xString;
            }

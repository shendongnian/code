            try
            {
                // create word application
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                // create object of missing value
                object miss = System.Reflection.Missing.Value;
                // create object of selected file path
                object path = filePath;
                // set file path mode
                object readOnly = false;
                // open document                
                Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                foreach (Microsoft.Office.Interop.Word.Table tbl in docs.Tables)
                {
                    tbl.Delete();
                }
                foreach (Microsoft.Office.Interop.Word.Shape shp in docs.Shapes)
                {
                    shp.Delete();
                }
                foreach (Microsoft.Office.Interop.Word.InlineShape ilshp in docs.InlineShapes)
                {
                    if (ilshp.Type == Microsoft.Office.Interop.Word.WdInlineShapeType.wdInlineShapePicture)
                        ilshp.Delete();
                }
                docs.Close();
            }

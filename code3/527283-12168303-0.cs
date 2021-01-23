     private static void FindAndReplaceImages(Word.Document d,
                                    BO.ImageReplace image)
        {
            object missing = System.Reflection.Missing.Value;
            List<Word.Range> ranges = new List<Microsoft.Office.Interop.Word.Range>();
            foreach (Word.InlineShape s in d.InlineShapes)
            {
                
                
                if (s.Type == Microsoft.Office.Interop.Word.WdInlineShapeType.wdInlineShapePicture)
                {
                    ranges.Add(s.Range);
                    s.Delete();
                }
            }
            
                foreach (Word.Range r in ranges)
                {
                    if (image.DataType == "image")//then image.Data is a location on disk
                    {
                        r.InlineShapes.AddPicture(image.Data, ref missing, ref missing, ref missing);
                    }
                    else if(image.DataType == "word")//then image.Data is a string
                    {
                        r.InsertBefore(image.Data);
                        
                    }
                }
            
        }

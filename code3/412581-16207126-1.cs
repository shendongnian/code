    public static string GetElementStream(PdfPage page, int elementIndex)
        {
            string strStreamValue;
            byte[] streamValue;
            strStreamValue = "";
            if (page.Contents.Elements.Count >= elementIndex)
            {
                PdfDictionary.PdfStream stream = page.Contents.Elements.GetDictionary(elementIndex).Stream;
                streamValue = stream.Value;
                foreach (byte b in streamValue)
                {
                    strStreamValue += (char)b;
                }
            }
            return strStreamValue;
        }

    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Xps.Packaging;
    
    namespace XPS_Data_Transfer
    {
        internal static class XpsDataReader
        {
            public static List<string> ReadXps(string address, int pageNumber)
            {
                var xpsDocument = new XpsDocument(address, System.IO.FileAccess.Read);
                var fixedDocSeqReader = xpsDocument.FixedDocumentSequenceReader;
                if (fixedDocSeqReader == null) return null;
    
                const string uniStr = "UnicodeString";
                const string glyphs = "Glyphs";
                var document = fixedDocSeqReader.FixedDocuments[pageNumber - 1];
                var page = document.FixedPages[0];
                var currentText = new List<string>();
                var pageContentReader = page.XmlReader;
    
                if (pageContentReader == null) return null;
                while (pageContentReader.Read())
                {
                    if (pageContentReader.Name != glyphs) continue;
                    if (!pageContentReader.HasAttributes) continue;
                    if (pageContentReader.GetAttribute(uniStr) != null)
                        currentText.Add(Dashboard.CleanReversedPersianText(pageContentReader.GetAttribute(uniStr)));
                }
                return currentText;
            }
        }
    }

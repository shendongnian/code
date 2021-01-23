    using System;
    using System.IO;
    using System.Windows.Xps.Packaging;
    class Tester
    {
        public static bool IsXps(string filename)
        {
            try
            {
                XpsDocument x = new XpsDocument(filename, FileAccess.Read);
                IXpsFixedDocumentSequenceReader fdsr = x.FixedDocumentSequenceReader;
                // Needed to actually try to find the FixedDocumentSequence
                Uri uri = fdsr.Uri;
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
    }

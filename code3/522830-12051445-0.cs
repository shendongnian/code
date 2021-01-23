      class Program
      {
        static void Main(string[] args)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
    
            word.Visible = true;
    
            string document = @"C:\bin\Debug\1.doc";
    
            if (document != null)
            {
                Document doc = word.Documents.Open(document, ReadOnly: false, Visible: true);
                doc.Activate();
    
                object missingObject = null;
    
                doc.ConvertNumbersToText();
    
                object item = WdGoToItem.wdGoToPage;
                object whichItem = WdGoToDirection.wdGoToFirst;
                object replaceAll = WdReplace.wdReplaceAll;
                object forward = true;
                object matchWholeWord = false;
                object matchWildcards = true;
                object matchSoundsLike = false;
                object matchAllWordForms = false;
                object wrap = WdFindWrap.wdFindAsk;
                object format = true;
                object matchCase = false;
                object originalText = "([!.:])^13(?[!.])";
                object replaceText = @"\1 \2";
    
                doc.GoTo(ref item, ref whichItem, ref missingObject, ref missingObject);
                foreach (Range rng in doc.StoryRanges)
                {
                    rng.Find.Font.Bold = 0;
    
                    rng.Find.Execute(ref originalText, ref matchCase,
                ref matchWholeWord, ref matchWildcards, ref matchSoundsLike, ref matchAllWordForms, ref forward,
                ref wrap, ref format, ref replaceText, ref replaceAll, ref missingObject,
                ref missingObject, ref missingObject, ref missingObject);
                }
    
            }
        }
    }

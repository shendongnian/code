     private static void HighlightText()
        {
            object fileName = "C:\\1.doc";
            object textToFind = "test1";
            object readOnly = true;
            Word.Application word = new Word.Application();
            Word.Document doc = new Word.Document();
            object missing = Type.Missing;
            try
            {
                doc = word.Documents.Open(ref fileName, ref missing, ref readOnly,
                                          ref missing, ref missing, ref missing,
                                          ref missing, ref missing, ref missing, 
                                          ref missing, ref missing, ref missing, 
                                          ref missing, ref missing, ref missing, 
                                          ref missing);
                doc.Activate();
                object matchPhrase = false;
                object matchCase = false;
                object matchPrefix = false;
                object matchSuffix = false;
                object matchWholeWord = false;
                object matchWildcards = false;
                object matchSoundsLike = false;
                object matchAllWordForms = false;
                object matchByte = false;
                object ignoreSpace = false;
                object ignorePunct = false;
                object highlightedColor = Word.WdColor.wdColorGreen;
                object textColor = Word.WdColor.wdColorLightOrange;
                Word.Range range = doc.Range();
                bool highlighted = range.Find.HitHighlight(textToFind,
                                                           highlightedColor,
                                                           textColor,
                                                           matchCase,
                                                           matchWholeWord,
                                                           matchPrefix,
                                                           matchSuffix,
                                                           matchPhrase,
                                                           matchWildcards,
                                                           matchSoundsLike,
                                                           matchAllWordForms,
                                                           matchByte,
                                                           false,
                                                           false,
                                                           false,
                                                           false,
                                                           false,
                                                           ignoreSpace,
                                                           ignorePunct,
                                                           false);
                System.Diagnostics.Process.Start(fileName.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                Console.ReadKey(true);
            }
        }

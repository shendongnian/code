    using WN = Microsoft.Office.Interop.Word;
    //...
            WN::Application WordApp;
            WordApp = new WN.Application();
    //...        
	    WN.Document WordDoc = WordApp.Documents.Open(Filename); //open document
            
            List<string> SelectedParagraphs = new List<string>();
            for(int i=1;i<WordDoc.Paragraphs.Count;i++) //numeration of paragraphs starts from 1
            {
                    string WordP = WordDoc.Paragraphs[i].Range.Text; // get paragraph text
                    string WordS = ((WN.Style)WordDoc.Paragraphs[i].get_Style()).NameLocal; //get paragraph style name
                    if (WordS=="Needed style")
                    {
                        SelectedParagraphs.Add(WordP);
                    }
            }

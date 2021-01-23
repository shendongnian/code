    using Microsoft.Office.Interop.Word;
    //for older versions of Word use:
    //using Word;
    namespace WordSpltter {
        class Program {
            static void Main(string[] args) {
                //Create a new instance of Word
                var app = new Application();
                //Show the Word instance.
                //If the code runs too slowly, you can show the application at the end of the program
                //Make sure it works properly first; otherwise, you'll get an error in a hidden window
                //(If it still runs too slowly, there are a few other ways to reduce screen updating)
                app.Visible = true;
                //We need a reference to the source document
                //It should be possible to get a reference to an open Word document, but I haven't tested it
                var doc = app.Documents.Open(@"path\to\file.doc");
                //(Can also use .docx)
                int pageCount = doc.Range().Information[WdInformation.wdNumberOfPagesInDocument];
                //We'll hold the start position of each page here
                int pageStart = 0;
                
                for (int currentPageIndex = 1; currentPageIndex <= pageCount; currentPageIndex++) {
                    //This Range object will contain each page.
                    var page = doc.Range(pageStart);
                    //Generally, the end of the current page is 1 character before the start of the next.
                    //However, we need to handle the last page -- since there is no next page, the 
                    //GoTo method will move to the *start* of the last page.
                    if (currentPageIndex < pageCount) {
                        //page.GoTo returns a new Range object, leaving the page object unaffected
                        page.End = page.GoTo(
                            What: WdGoToItem.wdGoToPage,
                            Which: WdGoToDirection.wdGoToAbsolute,
                            Count: currentPageIndex + 1
                        ).Start - 1;
                    } else {
                        page.End = doc.Range().End;
                    }
                    pageStart = page.End + 1;
                    //Copy and paste the contents of the Range into a new document
                    page.Copy();
                    var doc2 = app.Documents.Add();
                    doc2.Range().Paste();
                }
            }
        }
    }

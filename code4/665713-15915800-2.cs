    namespace VisioExample
    {
        using System;
        using Microsoft.Office.Interop.Visio;
    
        class Program
        {
            public static void Main(string[] args)
            {
                // Start Visio
                Application app = new Application();
    
                // Create a new document.
                Document doc = app.Documents.Add("");
                
                // The new document will have one page,
                // get the a reference to it.
                Page page1 = doc.Pages[1];
    
                // Add a second page.
                Page page2 = doc.Pages.Add();
    
                // Name the pages. This is what is shown in the page tabs.
                page1.Name = "Abc";
                page2.Name = "Def";
    
                // Move the second page to the first position in the list of pages.
                page2.Index = 1;                
            }
        }
    }

     button1_click(){
        //go site1 
        wb.Navigate("site1.com");
        //wait for documentCompleted before  continue to  execute  any further 
        waitWebBrowserToComplete(wb); 
        
        // set some values in html page
        wb.Document.GetElementById("input1").SetAttribute("Value", "hello");
        //  then click submit. (submit does navigation)
        wb.Document.GetElementById("formid").InvokeMember("submit");
        // then wait for doc complete        
        waitWebBrowserToComplete(wb);
       
        var processedHtml = wb.Document.GetElementsByTagName("HTML")[0].OuterHtml;
        var rawHtml = wb.DocumentText;
    }
    // helpers
    //instead of checking  readState . we get state from DocumentCompleted Event via bool value
    bool webbrowserDocumentCompleted = false;
    public static void waitWebBrowserToComplete(WebBrowser wb)
    {
      while (!webbrowserDocumentCompleted )
          Application.DoEvents();
      webbrowserDocumentCompleted = false;
    }
    form_load(){
      wb.DocumentCompleted += (o, e) => {
         webbrowserDocumentCompleted = true;
      };
    }

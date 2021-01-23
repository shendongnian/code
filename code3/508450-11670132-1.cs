    void worker_DoWork( object sender, DoWorkEventArgs e)
    {
       // Set up a string to hold our data so we only need to use the dispatcher in one place
       string toAppend = "";
       foreach (DocumentData doc in Docs)
       {
          toAppend = "";
          try
          {
             wsProxy.RefileDocument(doc);
             toAppend = String.Format("Refilling doc # {0}.{1}\u2028", doc.DocNum, doc.DocVer);  
          }
          catch (Exception exc)
          {
             if (exc.Message.Contains("Document is in use"))
                toAppend = String.Format("There was a problem refilling doc # {0}, it is in use.\u2028",doc.DocNum);
             else
                toAppend = String.Format("There was a problem refilling doc # {0} : {1}.\u2028", doc.DocNum, exc.Message);
          }
          // Update the text from the main thread to avoid exceptions
          Dispatcher.Invoke((Action)delegate
          {
             MainText.AppendText(toAppend);
          });
       }
    }

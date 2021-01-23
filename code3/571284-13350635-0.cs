    private void sendConfirmRequest(XmlManipulator requestXML)
    {
        //ConfirmConnector conn = new ConfirmConnector();
        file.WriteLine("Sending CONFIRM Request!");
        //AsyncCallback callBack = new AsyncCallback(processConfirmXML); // assign the callback method for this call
        
        //IAsyncResult r = conn.BeginProcessOperations(requestXML, callBack, AsyncState);
        //System.Threading.WaitHandle[] waitHandle = { r.AsyncWaitHandle }; // set up a wait handle so that the process doesnt automatically return to the ASPX page
        //System.Threading.WaitHandle.WaitAll(waitHandle, -1);
        file.WriteLine("Calling BeginProcessOperations");
        IAsyncResult result = conn.BeginProcessOperations(requestXML, null, null);
        // Wait for the WaitHandle to become signaled.
        result.AsyncWaitHandle.WaitOne();
        file.WriteLine("Calling EndProcessOperations");
        XmlNode root = conn.EndProcessOperations(result);
        processConfirmXML(root);
        file.WriteLine("got return XML");
        //writeXMLToFile("C:/response.xml",root.InnerXml);
        file.WriteLine(root.InnerXml);
        // Close the wait handle.
        result.AsyncWaitHandle.Close();
    }

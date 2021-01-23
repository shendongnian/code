    public void openWordDocument(string filePath)
    {
        object missing = System.Reflection.Missing.Value;
        //create a document in this path  
        object fileName = filePath;
        object wordApp = Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application"));
        //Setup our Word.Document  
        object wordDoc = wordApp.GetType().InvokeMember("Documents", System.Reflection.BindingFlags.GetProperty, null, wordApp, null);
        //Set Word to be not visible  
        wordApp.GetType().InvokeMember("Visible", System.Reflection.BindingFlags.SetProperty, null, wordApp, new object[] { true });
        //Open the word document fileName  
        object activeDoc = wordDoc.GetType().InvokeMember("Open", System.Reflection.BindingFlags.InvokeMethod, null, wordDoc, new Object[] { fileName });
    }

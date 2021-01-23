    try
    {
        FileStream sourceFile = null;
        Response.ClearContent(); // <<<---- Add this before `ContentType`.
        Response.ContentType = "application/text";
        .
        .
        Response.BinaryWrite(getContent);
        Response.End(); // <<<---- Add this at the end.
    }
    catch (System.Threading.ThreadAbortException) //<<-- Add this catch.
    {
        //Don't add anything here.
        //because if you write here in Response.Write,
        //that text also will be added to your text file.
    }
    catch (Exception exp)
    {
        throw new Exception("File save error! Message:<br />" + exp.Message, exp);
    }

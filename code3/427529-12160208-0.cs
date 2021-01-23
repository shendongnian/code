    foreach (OpenPop.Mime.MessagePart fileItem in elencoAtt)
    {
        System.Net.Mime.ContentDisposition cDisp = fileItem.ContentDisposition;
        //Check for the attachment...
        if (!cDisp.Inline)
        {
            // Attachment not in-line
        }
        else
        {
            // Attachment in-line
        }
    }

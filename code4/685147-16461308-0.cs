    private static string getAttachmentPath(Outlook.Attachment attachment)
    {
    	var path = System.IO.Path.Combine(Path.GetDirectoryName( Application.ExecutablePath), attachment.FileName);
    	attachment.SaveAsFile(path);
    	return path;
    }

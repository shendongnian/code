    ...
    var attachment = CreateAttachment(WriteFileToMemory(Common.TempPath + excelName), excelName);
    attachmentCollection.Add(attachment);
    ...
    private Stream WriteFileToMemory(string filePath)
    {
        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        _openedStreams.Add(fileStream);
        return fileStream;
    }
    public static Attachment CreateAttachment(Stream attachmentFile, string displayName)
    {
        var attachment = new Attachment(attachmentFile, displayName);
        attachment.ContentType = new ContentType("application/vnd.ms-excel");
        attachment.TransferEncoding = TransferEncoding.Base64;
        attachment.NameEncoding = Encoding.UTF8;
        string encodedAttachmentName = Convert.ToBase64String(Encoding.UTF8.GetBytes(displayName));
        encodedAttachmentName = SplitEncodedAttachmentName(encodedAttachmentName);
        attachment.Name = encodedAttachmentName;
        return attachment;
    }
    private static string SplitEncodedAttachmentName(string encoded)
    {
        const string encodingtoken = "=?UTF-8?B?";
        const string softbreak = "?=";
        const int maxChunkLength = 30;
        int splitLength = maxChunkLength - encodingtoken.Length - (softbreak.Length * 2);
        IEnumerable<string> parts = SplitByLength(encoded, splitLength);
        string encodedAttachmentName = encodingtoken;
        foreach (var part in parts)
        {
            encodedAttachmentName += part + softbreak + encodingtoken;
        }
        encodedAttachmentName = encodedAttachmentName.Remove(encodedAttachmentName.Length - encodingtoken.Length, encodingtoken.Length);
        return encodedAttachmentName;
    }
    private static IEnumerable<string> SplitByLength(string stringToSplit, int length)
    {
        while (stringToSplit.Length > length)
        {
            yield return stringToSplit.Substring(0, length);
            stringToSplit = stringToSplit.Substring(length);
        }
        if (stringToSplit.Length > 0)
        {
            yield return stringToSplit;
        }
    }

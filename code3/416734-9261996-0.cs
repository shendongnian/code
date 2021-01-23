    var query = from attachment in tent.Attachments
                where attachment.Attachment_Type == type &&
                      attachment.Attachment_Reference_Pk == ReferenceId
                select new { Attachment_Pk, Attachment_File_Path };
    // Force the rest to execute client-side.
    var attachmentNames = query.AsEnumerable()
                               .Select(x => new AttachmentList {
                                   Attachment_Pk = x.Attachment_Pk,
                                   Attachment_File_Path = x.Attachment_File_Path
                                                           .Split('$')[1]
                               })
                               .ToList();

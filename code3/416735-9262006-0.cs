    var attachmentNames = (from attachment in tent.Attachments
                            where (attachment.Attachment_Type == type && attachment.Attachment_Reference_Pk == ReferenceId)
                            select new { attachment.Attachment_Pk, attachment.Attachment_File_Path })
                            .AsEnumerable()
                            .Select(attachment =>
                            new AttachmentList
                            {
                                Attachment_Pk = attachment.Attachment_Pk,
                                Attachment_File_Path = attachment.Attachment_File_Path.Split(new[] { '$' })[1]
                            }).ToList();

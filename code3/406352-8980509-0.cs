    // Find files and get names.
    foreach (DocumentSection s in this.sections)
    {
        foreach (EmailAttachment a in s.SectionAttachments)
        {
            // Get file location, then clear attachment to release file handle.
            filesToDelete.Add(a.TempAttachmentFileLoc);
            //s.SectionAttachments.Remove(a);  // removed this!
            //a = null;
        }
        s.SessionAttachments.Clear();  // Added this
        //this.sections.Remove(s);  // Removed this
        //s = null;
    }
    this.sections.Clear();  // Added this

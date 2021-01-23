    // Check tags of all pages
    for (int idx = 0; idx < pageCount; idx++)
    {
      DocumentObject[] docObjects = docRenderer.GetDocumentObjectsFromPage(idx + 1);
      if (docObjects != null && docObjects.Length > 0)
      {
        Section section = docObjects[0].Section;
        DocumentSectionTag sectionTag = null;
        if (section != null)
          sectionTag = section.Tag as DocumentSectionTag;
        if (sectionTag != null && sectionTag.Name != sectionName)
        { 
          // Your code to handle the background information goes here

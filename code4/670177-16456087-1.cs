    String sourceDoc = dataDir + "source.docx";
    String destinationtDoc = dataDir + "destination.docx";
    
    // Initialize the Document instance with source and destination documents
    Document doc = new Document(sourceDoc);
    Document dstDoc = new Document();
    
    // Remove the blank default page from new document
    dstDoc.RemoveAllChildren();
    PageNumberFinder finder = new PageNumberFinder(doc);
    // Split nodes across pages
    finder.SplitNodesAcrossPages(true);
    // Get separate page sections
    ArrayList pageSections = finder.RetrieveAllNodesOnPages(1, 5, NodeType.Section);
    foreach (Section section in pageSections)
        dstDoc.AppendChild(dstDoc.ImportNode(section, true));
    dstDoc.LastSection.Body.LastParagraph.Remove();
    dstDoc.Save(destinationtDoc);

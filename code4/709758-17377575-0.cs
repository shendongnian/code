    PDFDoc doc = new PDFDoc(fileIn);
                RemoveCertainExistingLinks(doc, ExcusableLinks);
                doc.Save(fileOut, pdftron.SDF.SDFDoc.SaveOptions.e_linearized);
 
    public void RemoveCertainExistingLinks(PDFDoc doc, ICollection<string> excusedLinks)
            {
                for (PageIterator itr = doc.GetPageIterator(); itr.HasNext(); itr.Next())
                {
                    Page p = itr.Current();
     
                    int numAnnots = p.GetNumAnnots();
     
                    // Loops over the annotations backwards because the document is modified in
                    // place.
                    int i = numAnnots; 
                    while (i != 0)
                    {                    
                        i--;
     
                        Annot annot = p.GetAnnot(i);
                       
                        if (annot.GetType() != Annot.Type.e_Link || !annot.IsValid())
                        {
                            continue;
                        }
     
                        
                        pdftron.PDF.Action linkAction = annot.GetLinkAction();
                        if (linkAction.GetType() != pdftron.PDF.Action.Type.e_URI)
                        {
                            continue;
                        }
     
    
                        pdftron.SDF.Obj sdfobj = linkAction.GetSDFObj();
     
                        // this should be a dictionary
                         pdftron.SDF.Obj URIobj = sdfobj.FindObj("URI");
                         string URI = URIobj.GetAsPDFText();                   
                        
                      
                        p.AnnotRemove(i);
     
                      }
                }
            }

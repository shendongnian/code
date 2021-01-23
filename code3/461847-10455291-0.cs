    Page page = doc.GetPage(1);
    for (int i = 1; j < page.GetNumAnnots(); j++) {
    	Annot annot = page.GetAnnot(i);
    	if (!annot.IsValid())
    		continue;
    	var sdf = annot.GetSDFObj();
    	string uri = ParseURI(sdf);
    	Console.WriteLine(uri);
    }
    
    
    private string ParseURI(pdftron.SDF.Obj obj) {
    	try {
    		if (obj.IsDict()) {
    			var aDictionary = obj.Find("A").Value();
    			var uri = aDictionary.Find("URI").Value();
    			return uri.GetAsPDFText();
    		}
    	} catch (Exception ) {
    		return null;
    	}
    	return null;
    }

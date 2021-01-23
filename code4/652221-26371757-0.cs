    public IO.MemoryStream MergePdfForms(System.Collections.Generic.List<byte[]> files)
    {
    	if (files.Count > 1) {
    		using (System.IO.MemoryStream msOutput = new System.IO.MemoryStream()) {
    			using (iTextSharp.text.Document doc = new iTextSharp.text.Document()) {
    				using (iTextSharp.text.pdf.PdfSmartCopy pCopy = new iTextSharp.text.pdf.PdfSmartCopy(doc, msOutput) { PdfVersion = iTextSharp.text.pdf.PdfWriter.VERSION_1_7 }) {
    					doc.Open();
    					foreach (byte[] oFile in files) {
    						using (iTextSharp.text.pdf.PdfReader pdfFile = new iTextSharp.text.pdf.PdfReader(oFile)) {
    							for (i = 1; i <= pdfFile.NumberOfPages; i++) {
    								pCopy.AddPage(pCopy.GetImportedPage(pdfFile, i));
    								pCopy.FreeReader(pdfFile);
    							}
    						}
    					}
    				}
    			}
    
    			return msOutput;
    		}
    	} else if (files.Count == 1) {
    		return new System.IO.MemoryStream(files[0]);
    	}
    
    	return null;
    }

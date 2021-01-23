    public byte[] DocumentData
        {
            get 
            {
                this.document.ChangeDocumentType(WordprocessingDocumentType.MacroEnabledDocument);
                this.document.MainDocumentPart.Document.Save();
                this.document.Close();            
                byte[] documentData = this.stream.ToArray();
                return documentData;
            }
        }
    

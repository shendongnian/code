    public YourType(string documentType) {
        DocumentType = documentType;
    }
    private string documentType;
    public string DocumentType {
        get { return documentType; }
        set {
            // TODO: validate
            documentType = value;
        }
    }

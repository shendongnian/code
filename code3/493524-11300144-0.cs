    public static bool IsPasswordProtected(string pdfFullname) {
        try {
            PdfReader pdfReader = new PdfReader(pdfFullname);
            return false;
        } catch (BadPasswordException) {
            return true;
        }
    }

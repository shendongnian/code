    private readonly mnuForm _parentForm;
    public profFileDialog(mnuForm parentForm)
    {
        _parentForm = parentForm;
        KeyPreview = true; // <-- see Simon's Answer
        // other code ...
    }

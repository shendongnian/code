    public int OnAfterDocumentWindowHide(uint docCookie, IVsWindowFrame pFrame)
    {
        IVsTextView view = VsShellUtilities.GetTextView(pFrame);
        if (view != null)
        {
            views.Add(view);
        }
    }

    public int OnBeforeDocumentWindowShow(uint docCookie, int fFirstShow, IVsWindowFrame pFrame)
    {
        IVsTextView view = VsShellUtilities.GetTextView(pFrame);
        if (view != null)
        {
            views.Remove(view);
        }
        return VSConstants.S_OK;
    }

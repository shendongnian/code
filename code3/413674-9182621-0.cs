    static bool IsCodeDefWindow(
        IWpfTextView textView, 
        IVsEditorAdaptersFactoryService editorAdaptersFactoryService, 
        IVsCodeDefView vsCodeDefView)
    {
        var vsTextView = editorAdaptersFactoryService.GetViewAdapter(textView);
        if (vsTextView == null)
        {
            // Happens for unshimmed IWpfTextView instances
            return false;
        }
        int isCodeDef;
        return
            ErrorHandler.Succeeded(vsCodeDefView.IsCodeDefView(vsTextView, out isCodeDef)) &&
            isCodeDef != 0;
    }

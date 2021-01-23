    private bool CanEditFile()
    {
      // --- Check the status of the recursion guard
      if (_GettingCheckoutStatus) return false;
     
      try
      {
        _GettingCheckoutStatus = true;
     
        IVsQueryEditQuerySave2 queryEditQuerySave =
          (IVsQueryEditQuerySave2)GetService(typeof(SVsQueryEditQuerySave));
     
        // ---Now call the QueryEdit method to find the edit status of this file
        string[] documents = { _FileName };
        uint result;
        uint outFlags;
     
        int hr = queryEditQuerySave.QueryEditFiles(
          0, // Flags
          1, // Number of elements in the array
          documents, // Files to edit
          null, // Input flags
          null, // Input array of VSQEQS_FILE_ATTRIBUTE_DATA
          out result, // result of the checkout
          out outFlags // Additional flags
          );
        if (ErrorHandler.Succeeded(hr) && (result ==
          (uint)tagVSQueryEditResult.QER_EditOK))
        {
          return true;
        }
      }
      finally
      {
        _GettingCheckoutStatus = false;
      }
      return false;
    }

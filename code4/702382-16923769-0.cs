    public static string ShowErrors(System.Data.SqlServerCe.SqlCeException e)
    {
    System.Data.SqlServerCe.SqlCeErrorCollection errorCollection = e.Errors;
    StringBuilder bld = new StringBuilder();
    Exception inner = e.InnerException;
    if (!string.IsNullOrEmpty(e.HelpLink))
    {
        bld.Append("\nCommand text: ");
        bld.Append(e.HelpLink);
    }
    if (null != inner)
    {
        bld.Append("\nInner Exception: " + inner.ToString());
    }
    // Enumerate the errors to a message box.
    foreach (System.Data.SqlServerCe.SqlCeError err in errorCollection)
    {
        bld.Append("\n Error Code: " + err.HResult.ToString("X", System.Globalization.CultureInfo.InvariantCulture));
        bld.Append("\n Message   : " + err.Message);
        bld.Append("\n Minor Err.: " + err.NativeError);
        bld.Append("\n Source    : " + err.Source);
        // Enumerate each numeric parameter for the error.
        foreach (int numPar in err.NumericErrorParameters)
        {
            if (0 != numPar) bld.Append("\n Num. Par. : " + numPar);
        }
        // Enumerate each string parameter for the error.
        foreach (string errPar in err.ErrorParameters)
        {
            if (!string.IsNullOrEmpty(errPar)) bld.Append("\n Err. Par. : " + errPar);
        }
      }
      return bld.ToString();
    }

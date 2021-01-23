    public void Test()
    {
      SqlCeConnection conn = new SqlCeConnection(@"Data Source=/Application/Database.sdf;");
      try
      {
        conn.Open();
        label1.text = "Connection!";
      }
      catch (SqlCeException ee)  // <- Notice the use of SqlCeException to read your errors
      {
        SqlCeErrorCollection errorCollection = ee.Errors;
        StringBuilder bld = new StringBuilder();
        Exception inner = ee.InnerException;
        if (null != inner) 
        {
          MessageBox.Show("Inner Exception: " + inner.ToString());
        }
        // Enumerate the errors to a message box.
        foreach (SqlCeError err in errorCollection) 
        {
          bld.Append("\n Error Code: " + err.HResult.ToString("X")); 
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
            if (String.Empty != errPar) bld.Append("\n Err. Par. : " + errPar);
          }
        }
        label1.text = bld.ToString();
        bld.Remove(0, bld.Length);
      }
    }

    public void OnTagsReported()
    {
      if (dgvScanResult.InvokeRequired)
      {
        dgvScanResult.Invoke(new MethodInvoker(OnTagsReported), null);
        return;
      }
    
      for( var i = dgvScanResult.Rows.Count - 1; i >= 0; i-- )
      {
        var row = dgvScan.Rows[ i ];
        ...
      }  
      ...
    }

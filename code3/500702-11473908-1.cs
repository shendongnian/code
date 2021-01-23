    public void DataChanged(object sender, NewDataEventArgs e)
    {
          if(InvokeRequired)
          {
              BeginInvoke((MethodInvoker)(()=>DataChanged(sender, e)), null);
              return;
          }
          // get the data
          mTreeView.BeginUpdate();
          // perform update
          mTreeView.EndUpdate();
    }

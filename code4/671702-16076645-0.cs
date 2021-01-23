    try
        {
            ... some operation ....
        }
    catch (Exception err)
        {
           if (txtErrors.InvokeRequired)
            {
                txtErrors.BeginInvoke(new MethodInvoker(
                    delegate { txtErrors.AppendText(err.Message); })
                    );
            }
        }

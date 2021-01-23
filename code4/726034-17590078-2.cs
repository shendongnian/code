    public static bool? ShowSettingsDialogFor(ICustomCustomer)
    {
       if (cust is BasicCustomer)
       {
          DialogResult result = (new BCustomerSettingsDialog()).ShowDialog();
          switch (result)
          {
              case DialogResult.OK:
              case DialogResult.Yes:
                  return true;
              case DialogResult.No:
              case DialogResult.Abort:
                  return false;
              case DialogResult.None:
              case DialogResult.Cancel:
                  return null;
              default:
                  throw new ApplicationException("Unexpected dialog result.")
          }
       }
    }

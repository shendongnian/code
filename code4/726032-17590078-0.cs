    public static bool? ShowSettingsDialogFor(ICustomCustomer)
    {
       if (cust is BasicCustomer)
       {
          DialogResult result = (new BCustomerSettingsDialog()).ShowDialog();
          if (result == DialogResult.OK || result == DialogResult.Yes)
              return true;
          if (result == DialogResult.No || result == DialogResult.Abort)
              return false;
          if (result == DialogResult.None || result == DialogResult.Cancel)
              return null;
          throw new ApplicationException("Unexpected dialog result.")
       }
    }

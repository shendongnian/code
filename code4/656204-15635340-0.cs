    public void OpenOrActivateForm(string formType)
    {
      var formType = Type.GetType(formType);
      var form = Globale.IsFormAlreadyOpen(formType);
    
      if(form == null)
      {
        form = Activator.CreateInstance(formType);
        from.Show(this);
      }
      else
      {
        form.Activate();
        form.WindowState = FormWindowState.Normal;
        form.BringToFront();
      }
    }

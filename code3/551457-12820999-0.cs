    FormCollection fc = Application.OpenForms;
    if (fc!= null && fc.Count > 0)
    {
       for (int i = 1; i < fc.Count; i++)
        {
           if (fc!= null && fc.IsDisposed!= true)
            {
              fc.Dispose();
            }
       }
    }

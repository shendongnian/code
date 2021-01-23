    if (IsValid)
    {
      Incident i = new Incident();
      i.CustomerID = Convert.ToInt32(ddlCustomer.SelectedValue);
      i.ProductCode = ddlProduct.SelectedValue;
      i.DateOpened = DateTime.Today;
      i.Title = txtTitle.Text;
      i.Description = txtDescription.Text;
    
      try
      {
        IncidentDB.InsertIncident(i);
      }
      catch (Exception ex)
      {
      }
    }

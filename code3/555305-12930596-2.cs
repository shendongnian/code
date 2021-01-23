    foreach (Outlook.Inspector inspector in this.Application.Inspectors)
    {
      Outlook.AppointmentItem item 
        = inspector.CurrentItem as Outlook.AppointmentItem;
      Outlook.UserProperty property = item.UserProperties["crmid"];
      String crmId = String.Empty;
      if (property != null)
        crmId = (String) item.UserProperties["crmid"].Value;
    }

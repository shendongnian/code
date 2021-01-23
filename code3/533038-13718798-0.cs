    foreach (Message msg in eventObj.GetMessages())
    {
       Element element = msg.GetElement("securityData");
       
       for (int i = 0; i < element.NumValues; i++)
       {
          Element security = element.GetValueAsElement(i);
          string ticker = security.GetElementAsString("security");
          Element fields = security.GetElement("fieldData");
          decimal px_last  = Convert.toDecimal(fields.GetElementAsFloat64("PX_LAST"));
       }
    }

    //Setting the property with Exchange webservice:
    
    string guid = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
                             
    Guid MY_PROPERTY_SET_GUID = new Guid(guid); 
    
    Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition extendedPropertyDefinition =
    new Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition(MY_PROPERTY_SET_GUID, "Archivado", MapiPropertyType.String);
    //Recover the property using Outlook:
    Outlook.MailItem item = (Outlook.MailItem)e.OutlookItem;
    
    Outlook.UserProperties mailUserProperties = item.UserProperties;
    
    dynamic property=item.PropertyAccessor.GetProperty("http://schemas.microsoft.com/mapi/string/{Outlook.MailItem item = (Outlook.MailItem)e.OutlookItem;
                Outlook.UserProperties mailUserProperties = item.UserProperties;
                dynamic property=item.PropertyAccessor.GetProperty("http://schemas.microsoft.com/mapi/string/{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}/Archivado");

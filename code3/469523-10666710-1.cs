    join licence in entities.ClientLicences on
    SqlFunctions.StringConvert((double)client.Client_ID)
    equals
    licence.ClientLicence_ClientID
    into clientGroup

    join licence in entities.ClientLicences on
    new { clientId = SqlFunctions.StringConvert((double)client.Client_ID) }
    equals
    new { licence.ClientLicence_ClientID }
    into clientGroup

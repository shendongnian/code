    var lsSystem= db.tblSystem.Select (s =>new SystemDTO()
    										{
    											pkSystemId=s.pkSystemID,
    											Name=s.systemName,
    											fkCompanyId=s.fkCompanyID
    										}
    								).ToLookup (s =>s.fkCompanyId);

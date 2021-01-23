     SearchResponse response = (SearchResponse)connection.SendRequest(request);
                DirectoryAttribute attribute = response.Entries[0].Attributes["ntSecurityDescriptor"];
                if (attribute != null)
                {
                    const string PASSWORD_GUID = "{ab721a53-1e2f-11d0-9819-00aa0040529b}";
                    const int ADS_ACETYPE_ACCESS_DENIED_OBJECT = 6;
                    bool fEveryone = false;
                    bool fSelf = false;
                    ActiveDs.ADsSecurityUtility secUtility = new ActiveDs.ADsSecurityUtility();
                    ActiveDs.IADsSecurityDescriptor sd = (IADsSecurityDescriptor)secUtility.ConvertSecurityDescriptor((byte[])attribute[0], (int)ADS_SD_FORMAT_ENUM.ADS_SD_FORMAT_RAW, (int)ADS_SD_FORMAT_ENUM.ADS_SD_FORMAT_IID);
                    ActiveDs.IADsAccessControlList acl = (ActiveDs.IADsAccessControlList)sd.DiscretionaryAcl;
                    foreach (ActiveDs.IADsAccessControlEntry ace in acl)
                    {
                        if ((ace.ObjectType != null) && (ace.ObjectType.ToUpper() == PASSWORD_GUID.ToUpper()))
                        {
                            if ((ace.Trustee == "Everyone") && (ace.AceType == ADS_ACETYPE_ACCESS_DENIED_OBJECT))
                            {
                                fEveryone = true;
                            }
                            if ((ace.Trustee == @"NT AUTHORITY\SELF") && (ace.AceType == ADS_ACETYPE_ACCESS_DENIED_OBJECT))
                            {
                                fSelf = true;
                            }
                            break;
                        }
                    }
                    if (fEveryone || fSelf)
                    {
                        return Global.RequestContants.CANT_CHANGE_PASSWORD;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
               

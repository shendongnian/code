      List<tbl_inv_emoheader> CheckMsgid = (from EMOheader in InvData.tbl_inv_emoheaders
                                                      where (EMOheader.bln_export == true && (from i in GetEmail() select i).Contains(EMOheader.str_destbranch))
                                                      select EMOheader).ToList();
    private static IEnumerable<string> GetEmail()
        {
            List<string> strEmails;
            using (SharedSynchDataContext dc = new SharedSynchDataContext(Connections.Getencompass3()))
            {
                strEmails= (from l in dc.system_contacts
                        where (l.rovctrlvan_email != string.Empty)
                        select l.systemcode).ToList();
            }
            return strEmails;
        }

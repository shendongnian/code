    private static readonly ReadOnlyDictionary<string, UserTitles> authorities;
    static PublicFunctions()
    {
        Dictionary<string, UserTitles> authoritiesFill = new Dictionary<string, clsUserTitles>();
        using (DataTable dtTemp = DbConnection.db_Select_DataTable("select * from myTable"))
        {
            foreach (DataRow drw in dtTemp.Rows)
            {
                UserTitles userTitle = new UserTitles
                {
                  AuthorityLevel = Int32.Parse(drw["Level"].ToString()),
                  TitleTurkish = drw["Title_tr"].ToString();
                  TitleEnglish = drw["Title_en"].ToString();
                }
                authoritiesFill.Add(drw["authorityLevel"].ToString(), userTitle);
            }
        }
        authorities = new ReadOnlyDictionary<string, UserTitles>(authoritiesFill);
    }

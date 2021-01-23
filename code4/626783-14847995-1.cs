    List<BIODATA_MA_Entity> list = new List<BIODATA_MA_Entity>();
    for (int i = 0; i < result.Count(); i++)
    {
        BIODATA_MA c = new BIODATA_MA();
        INDUSTRY_MA im = new INDUSTRY_MA();
        c.ACCOUNT_ID = result.ElementAt(i).ACCOUNT_ID;
        c.FULL_NAME = result.ElementAt(i).FULL_NAME;
        c.RESUME_HEADELINE = result.ElementAt(i).RESUME_HEADELINE;
        c.KEY_SKILL = result.ElementAt(i).KEY_SKILL;
        c.TOTAL_EXPERIENCE = result.ElementAt(i).TOTAL_EXPERIENCE;
        c.PropIndustryNm = result.ElementAt(i).INDUSTRY;
        c.PropFunctionalNm = result.ElementAt(i).FUNCTIONAL_AREA;
        c.PropGraduNm = result.ElementAt(i).GRADU;
        c.PropPostGraduNm = result.ElementAt(i).POST_GRADU;
        //  c.TRANS_DATE = result.ElementAt(i).TRANS_DATE;
        list.Add(c);
    }

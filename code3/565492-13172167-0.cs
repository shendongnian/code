    const string cChalMemNameConst = "ChalMem_cnst";
    
    public List<challenge.Member> Members
    {
        get
        {
            if (!(ViewState[cChalMemNameConst] is List<challenge.Member>))
            {
                // need to fix the memory and added to viewstate
                ViewState[cArrNameConst] = new List<challenge.Member>();
            }
    
            return (List<challenge.Member>)ViewState[cChalMemNameConst];
        }
    }

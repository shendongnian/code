    public bool IsAccept()
    {
        //check the status is accept
        return Status != null && Status.ToLower() == "accept";
    }
    public bool IsRefer()
    {
        //check the status is refer
        return Status != null && Status.ToLower() == "refer";
    }
    public bool IsAnyReviewState()
    {
        return IsAccept() || IsRefer();
    }

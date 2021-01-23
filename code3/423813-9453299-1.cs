    private static bool _isCheckingPending;
    public static bool IsCheckingPending 
    { 
        get 
        {             
            bool pending = ListPapers.Count(paper => paper.IsPending == true) > 0;
            if (pending != _isCheckingPending) 
            {
               PropertyChanged("IsCheckingPending");
               _isCheckingPending = pending;
            }
            
            //List has items and it is not null, so intentionally removed the checks. 
            return _isCheckingPending;
        } 
    } 

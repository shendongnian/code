    private bool GenericCompareLists<T1, T2>(List<T1> cdssList, List<T2> spamisList, object sender, Func<T1, T2, bool> filterLambda ,  Func<T1, T2, bool> compareLambda )
    {
        bool passed = true;
        foreach ( T2 spamisCv in spamisList )
        {
            List<T1> cdssSubList = cdssList.Where(l => filterLambda(l, spamisCv)).ToList();
            if ( cdssSubList.Count != 1 )
            {
                log.Error( "..." );
                passed = false;
            }
            else
            {
                T1 cdssCv = cdssSubList.First();
    
                if ( compareLambda( cdssCv, spamisCv) )// comparing the sum of all check_amt for this type, cdss vs spamis - EWB
                {
                    log.Error( "Failed in comparison f" + sender.ToString()  );
                    passed = false;
                }
            }
        }
        return passed;
    }

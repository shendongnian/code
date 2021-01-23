    var result = Test_Criteria.Pass;
    if ( */fail condition*/ )
    {
        return Test_Criteria.Fail;  
    }
    if ( */another fail condition*/ )
    {
        return Test_Criteria.Fail;  
    }
    if( */warning condition*/ )
    {
        result = Test_Criteria.Warning;
    }
    else if( */another warning condition*/ )
    {
        result = Test_Criteria.Warning;
    }
    return result;

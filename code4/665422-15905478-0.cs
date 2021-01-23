     List<DateTime> dtList = new List<DateTime>();
     dtList.Add(OpenDtim.AddMinutes(45));
     while (OpenDtim < CloseDtim)
     {
        OpenDtim = OpenDtim.AddMinutes(15);
        dtList.Add(OpenDtim);
        
     }
    return dtList;

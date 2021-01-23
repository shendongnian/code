    // Start user process
    EPS30Ora.EPS30Svr svr = new EPS30Ora.EPS30Svr();
    if (Users.Exists(Username => Username.Username.Equals(inputparams.Username))) {
     // do something
    }
    else {
        
    }
...
    public LogOn(EPS30Ora.EPS30Svr svr, input_params inputparams)
    {
    Log_Res = svr.LogOnEx("EDEESTE", inputparams.VSID, inputparams.Username, inputparams.Password, "EPS30Ora", ref inputparams.ck);
    }

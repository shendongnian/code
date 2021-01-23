    var
      ppa1, ppa2: IProcPreviewEndArgs;
    ....
    ppa1 := CoProcPreviewEndArgs.Create;   
    ppa1.CreateNew(Res);                   
    ppa2 := IProcPreviewEndArgs(Res);    
    ppa2.CreateNew(Res); 

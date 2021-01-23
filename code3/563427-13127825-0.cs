    string data = @"NM1*QC*1*JENNINGS*PHILLIP~
    OTI*IA*IX*NA~
    REF*G1*J EVERETTE~
    REF*11*0113722463~
    AMT*GW*127.75~
    NM1*QC*1*JENNINGS*PHILLIP~
    OTI*IA*IX*NA~
    REF*G1*J EVERETTE~
    REF*11*0113722462~
    AMT*GW*10.99~
    NM1*QC*1*JENNINGS*PHILLIP~";
    
    string pattern = @"^(?<Command>\w{3})((?:\*)(?<Value>[^~*]+))+";
    
    var lines = Regex.Matches(data, pattern, RegexOptions.Multiline)
                     .OfType<Match>()
                     .Select (mt => new
                     {
                        Op   = mt.Groups["Command"].Value,
                        Data = mt.Groups["Value"].Captures.OfType<Capture>().Select (c => c.Value)
                     }
                     );

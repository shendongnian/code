    DateTime Result = new DateTime();
    if (DateTime.TryParseExact("yourDate", "YYYYMMDD", out Result)) { /*ok*/}
    else
        if (DateTime.TryParseExact("yourDate", "YYMMDD", out Result)) { /*ok*/}
        else
            // and so on ...

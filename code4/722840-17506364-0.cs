    string myString = " The objective for test.\vVision\v* Deliver a test goals\v** Comprehensive\v** Control\v* Alignment with cross-Equities strategy\vApproach\v*An acceleration";
    string[] delimiters = new string[] { "\\v" };
    string[] split = myString.Split(delimiters, StringSplitOptions.None);
    for (int i = 1; i < split.Length; i++)
    {
    }

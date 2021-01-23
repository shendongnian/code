Most normal numerical types have parse methods. Use TryParse if you're unsure if it's valid (Trying to parse "xyz" as a number will throw an exception)
For custom parsing you can define a NumberFormatInfo like this:
    var strInput = "1.000.000";
    var numberFormatInfo = new NumberFormatInfo
    {
        NumberDecimalSeparator = ",",
        NumberGroupSeparator = "."
    };
    double dbl = Double.Parse(strInput, numberFormatInfo);

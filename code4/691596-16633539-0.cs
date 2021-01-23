    var value = "१२३.३२१";
    var str = string.Join("", 
         value.Select(c => c == '.' ? "." : char.GetNumericValue(c).ToString()));
    var res = double.Parse(str,System.Globalization.NumberFormatInfo.InvariantInfo);
    Console.Write(res);

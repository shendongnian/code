    using System.Text.RegularExpressions;
    ...
    const string pattern = @"^\d+\.\d+\.\d+$";
    Regex.IsMatch("90.11103.41", pattern);       //true
    Regex.IsMatch("90440036.1112.227", pattern); //true
    Regex.IsMatch("90.1112.228", pattern);       //true
    Regex.IsMatch("90.1001.0009", pattern);      //true

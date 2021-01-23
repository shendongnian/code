    using System.Text.RegularExpressions;
    
    Regex regex = new Regex( "\\b(?:0|\\.)+\\b" );
    
    string input = "John, Dog,0, 00,000.0000, 0, 0.00, 123, 007,0";
    string result = regex.Replace( input, "0.00");

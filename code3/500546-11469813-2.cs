    using System.Configuration;
    // ...
    private static readonly string[] countries =  ConfigurationManager
        .AppSettings["countries"] // configuration setting with key "countries"
        .Split(',') // split comma-delimited values
        .Select(a=>a.Trim()) // trim each value (remove whitespace)
        .OrderBy(a=>a) // sort list (for binary search)
        .ToArray(); // convert to array

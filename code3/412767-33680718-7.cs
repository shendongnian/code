    module TextNormalizer
    
    open System;
    open System.Collections.Generic;
    open System.Linq;
    open System.Text.RegularExpressions;
    
    let spaceRegex = new Regex(@"\s+");
    let normalizeTextRegexStrict = new Regex( String.Join("|", [| @"[^\w\s]"; @"[0-9]+"; "_" |]), RegexOptions.Compiled);
    let normalizeTextRegexApostrophe = new Regex( String.Join("|", [| @"[^'\w\s]"; @"[0-9]+"; "_" |]), RegexOptions.Compiled);
    
    /// <summary>
    /// Replaces all punctuation with whitspace, apostrophe optional. Will return string matching original text with punctuation
    /// removed, text lowercased, and words evenly delimited with whitespace
    /// </summary>
    /// <param name="normedLine"></param>
    /// <param name="removeApostrophe"></param>
    let Normalize( normedLine ) ( removeApostrophe ) =
        let normedLine =
            if removeApostrophe then
                normalizeTextRegexStrict.Replace(normedLine, " "); // replace all punctuation with whitespace
            else
                normalizeTextRegexApostrophe.Replace(normedLine, " "); // replace all except apostrophe with whitespace
    
        //return
        spaceRegex.Replace( normedLine, " " )  // reduce continguous whitespace to a single space
            .Trim()                                         // get rid of any whitespace on ends
            .ToLower();                                     // lowercase whole thing

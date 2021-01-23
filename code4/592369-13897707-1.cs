    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace renamer
    {
        class RenameImpl
        {
            public static void RenameWithPatterns(string path,
                string curpattern, string newpattern, bool caseSensitive)
            {
                var placeholderNames = new List<string>();
    
                // Extract all the cur_placeholders from the user's input pattern
                var input_regex = new Regex(@"(\%[^%]+\%)");
                var cur_matches = input_regex.Matches(curpattern);
                var new_matches = input_regex.Matches(newpattern);
                var regex_pattern = new StringBuilder();
    
                if (!caseSensitive)
                    regex_pattern.Append("(?i)");
                regex_pattern.Append('^');
    
                // Do a pass over the matches and grab info about each capture
                var cur_placeholders = new List<Tuple<string, int, int>>();
                var new_placeholders = new List<Tuple<string, int, int>>();
                for (var i = 0; i < cur_matches.Count; ++i)
                {
                    var m = cur_matches[i];
                    cur_placeholders.Add(new Tuple<string, int, int>(m.Value, m.Index, m.Length));
                }
                for (var i = 0; i < new_matches.Count; ++i)
                {
                    var m = new_matches[i];
                    new_placeholders.Add(new Tuple<string, int, int>(m.Value, m.Index, m.Length));
                }
    
                // Build the regular expression
                for (var i = 0; i < cur_placeholders.Count; ++i)
                {
                    var ph = cur_placeholders[i];
                    
                    // Get the literal before the first capture if it is the first one
                    if (i == 0 && ph.Item2 > 0)
                        regex_pattern.Append(Regex.Escape(curpattern.Substring(0, ph.Item2)));
    
                    // Generate the capture for the placeholder
                    regex_pattern.AppendFormat("(?<{0}>.*?)", ph.Item1.Replace("%", ""));
    
                    // The literal after the placeholder
                    if (i + 1 == cur_placeholders.Count)
                        regex_pattern.Append(Regex.Escape(curpattern.Substring(ph.Item2 + ph.Item3)));
                    else
                        regex_pattern.Append(Regex.Escape(curpattern.Substring(ph.Item2 + ph.Item3,
                            cur_placeholders[i + 1].Item2 - (ph.Item2 + ph.Item3))));
                }
    
                regex_pattern.Append('$');
    
                var re = new Regex(regex_pattern.ToString());
    
                foreach (var pathname in Directory.EnumerateFileSystemEntries(path))
                {
                    var file = Path.GetFileName(pathname);
                    var m = re.Match(file);
    
                    if (!m.Success)
                        continue;
    
                    // New name is initially same as target pattern 
                    var newname = newpattern;
    
                    // Iterate through the placeholder names
                    for (var i = new_placeholders.Count; i > 0; --i)
                    {
                        // Target placeholder name
                        var tn = new_placeholders[i-1].Item1.Replace("%", "");
    
                        // Get captured value for this capture
                        var ct = m.Groups[tn].Value;
    
                        // Perform the replacement
                        newname = newname.Remove(new_placeholders[i - 1].Item2,
                            new_placeholders[i - 1].Item3);
                        newname = newname.Insert(new_placeholders[i - 1].Item2, ct);
                    }
    
                    Debug.Print("Rename from {0} to {1}", file, newname);
                }
            }
        }
    }

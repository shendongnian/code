    Dictionary<string, string> replacements = new Dictionary<string, string>
                                              {
                                                  { "echo", "PRINT" },
                                                  { "<?php", "<?" },
                                                  { "CURL", "(space)" }
                                              }
    string yourString; //this is your starter string, populate it with whatever
   
    foreach (var item in replacements)
    {
        yourString = yourString.Replace(item.Key, item.Value);
    }

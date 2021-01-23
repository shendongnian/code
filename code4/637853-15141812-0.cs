      public string output { get; set; }
      string input="Hello, my [FirstName] name is John. I worked in England [nearLondon] on a real german restaurant.".
      static readonly Regex re = new Regex(@"\{([^\}]+)\}", RegexOptions.Compiled);
     
      StringDictionary fields = new StringDictionary();
      fields.Add("FirstName", yourname);
      fields.Add("nearLondon", yournearLondon);
      output = re.Replace(input, delegate(Match match)
            {
                return fields[match.Groups[1].Value];
            });

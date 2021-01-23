        if(pattern1.IsMatch(source) && pattern1.IsMatch(target))
        {
            var pattern1 = New Regex(":\d{1,3}-{1}");
            var source = "tcm:7-426-8";
            var target = "tcm:10-15-2";
    
            var res = pattern1.Replace(source, pattern1.Match(target).Value);
            // "tcm:10-426-8"
        }
          

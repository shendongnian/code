    var newstr = Regex.Replace(
                    input, 
                    @"rgb\([ ]*(\d+)[ ]*,[ ]*(\d+)[ ]*,[ ]*(\d+)[ ]*\)", 
                    m => {
                        return "#" + Int32.Parse(m.Groups[1].Value).ToString("X2") +
                        Int32.Parse(m.Groups[2].Value).ToString("X2") +
                        Int32.Parse(m.Groups[3].Value).ToString("X2");
                    }
                );

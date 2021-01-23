            string input = @"
            <div>
                <p><span><br></span></p>
                <span>a<br/>bc</span>
                <p>te<br>st</p>
                <p>\n<span>\n</span></p>
                <p><span><br/></span></p>
            </div>
            ";
            string pattern = @"(<p>)?(\\n|<br/?>)?<span>(<br/?>|\\n)</span>(</p>)?";
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(pattern);
            string final = reg.Replace(input, String.Empty);
            Console.WriteLine(final);
        }

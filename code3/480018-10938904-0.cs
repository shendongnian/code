       var s = Regex.Matches(input_string, "[a-z]+(_*-*[a-z0-9]*)*", RegexOptions.IgnoreCase);
                string output_string="";
                foreach (Match m in s)
                {
                    output_string = output_string + m;
                    
                }
        MessageBox.Show(output_string);

            string str = @"something here LOC_POS(45;9);Some string or html content <br> here LOC_POS(45.21312;9.1232123);LOC_POS(45,32;9,12);  some other string...";
            Regex test = new Regex(@"(LOC_POS\([\d\.,]+;[\d\.,]+\);)");
            string[] segments = test.Split(str);
            StringBuilder sb = new StringBuilder();
            foreach (string s in segments)
                if(!String.IsNullOrEmpty(s))
                    sb.AppendLine(s);
            textBox1.Text = sb.ToString();

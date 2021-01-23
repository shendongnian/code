            var data = new List<string>
                {
                    "0.46578",
                    "12.314213",
                    "Error: Could not calculate value.",
                    "1.444876",
                };
            double d;
            var good = data.Where(s => Double.TryParse(s, out d)).Select(Double.Parse);
            var bad = data.Where(s => !Double.TryParse(s, out d)).Select(x => new
                {
                    key = data.IndexOf(x),
                    value = x
                }).ToDictionary(x => x.key, x => x.value);
            
            textBox1.AppendTextAddNewLine("Good Data:");
            WriteDataToTextBox(good);
            
            textBox1.AppendTextAddNewLine(String.Format("{0}{0}Bad Data:", Environment.NewLine));
            WriteDataToTextBox(bad);

        var list = new string[] { TextBox1.Text, TextBox2.Text, TextBox3.Text };
        list = list.OrderBy(x => ParseStringToInt(x)).ToArray();
        private int ParseStringToInt(string value)
        {
            int result;
            int.TryParse(value, out result);
            return result;
        }

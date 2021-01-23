        Dictionary<string, string> ReplaceDict = new Dictionary<string, string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            //Reverse Letters
            ReplaceDict.Add("a", "z");
            ReplaceDict.Add("b", "y");
            ReplaceDict.Add("c", "x");
            ReplaceDict.Add("d", "w");
            ReplaceDict.Add("e", "v");
            ReplaceDict.Add("f", "u");
            ReplaceDict.Add("g", "t");
            ReplaceDict.Add("h", "s");
            ReplaceDict.Add("i", "r");
            ReplaceDict.Add("j", "q");
            ReplaceDict.Add("k", "p");
            ReplaceDict.Add("l", "o");
            ReplaceDict.Add("m", "n");
            ReplaceDict.Add("n", "m");
            ReplaceDict.Add("o", "l");
            ReplaceDict.Add("p", "k");
            ReplaceDict.Add("q", "j");
            ReplaceDict.Add("r", "i");
            ReplaceDict.Add("s", "h");
            ReplaceDict.Add("t", "g");
            ReplaceDict.Add("u", "f");
            ReplaceDict.Add("v", "e");
            ReplaceDict.Add("w", "d");
            ReplaceDict.Add("x", "c");
            ReplaceDict.Add("y", "b");
            ReplaceDict.Add("z", "a");
            //Reverse numbers
            ReplaceDict.Add("0", "9");
            ReplaceDict.Add("1", "8");
            ReplaceDict.Add("2", "7");
            ReplaceDict.Add("3", "6");
            ReplaceDict.Add("4", "5");
            ReplaceDict.Add("5", "4");
            ReplaceDict.Add("6", "3");
            ReplaceDict.Add("7", "2");
            ReplaceDict.Add("8", "1");
            ReplaceDict.Add("9", "0");
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            StringBuilder output = new StringBuilder();
            string input = "a29z3";
            foreach (var c in input.ToCharArray())
            {
                output.Append(ReplaceDict[c.ToString()]);
            }
            MessageBox.Show(output.ToString()); 
        }

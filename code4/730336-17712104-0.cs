     List<Level> levels = new List<Level>();
        int[] val = new int[255];
        private void Form1_Load(object sender, EventArgs e)
        {
            val[(byte)'I'] = 1;
            val[(byte)'V'] = 5;
            val[(byte)'X'] = 10;
            val[(byte)'L'] = 50;
            val[(byte)'C'] = 100;
            val[(byte)'D'] = 500;
            val[(byte)'M'] = 1000;
            levels.Clear();
            levels.Add(new Level('I', 'V', 'X'));
            levels.Add(new Level('X', 'L', 'C'));
            levels.Add(new Level('C', 'D', 'M'));
        }
        int fromRoman(string n)
        {
            n = n.ToUpper();
            var result = 0;
            var lastDigit = 0;
            for (var pos = n.Length - 1; pos >= 0; pos--)
            {
                var curDigit = val[(byte)n[pos]];
                if (curDigit >= lastDigit)
                    result += curDigit;
                else
                    result -= curDigit;
                lastDigit = curDigit;
            }
            return result;
        }
        public class Level
        {
            public Level(char i, char v, char x)
            {
                this.i = i;
                this.x = x;
                this.v = v;
            }
            public char i;
            public char v;
            public char x;
        }

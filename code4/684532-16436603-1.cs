        private void Form1_Load(object sender, EventArgs e)
        {
            String first = "20 $ to euro";
            String[] result = first.Split(null);
            for (int i = 0; i < result.Count(); i++)
            {
                MessageBox.Show(result[i]);
                switch (i)
                {
                    case 0: getCurrencyValue(result[i]); break;
                    case 1: parseCurrencyFrom(result[i]); break;
                    case 2: parseCurrencyTo(result[i]); break;
                }
            }
        }
        public void parseCurrencyTo(String currencyCode)
        {
            switch (currencyCode)
            {
                case "euro": stuff(); break;
                case "$": stuff() break;
            }
        }

        /// <summary>
        /// Using struct
        /// </summary>
        struct twoStringValue
        {
            public string s1, s2;
        }
        public twoStringValue PlayerCards(string player1C1, string player1C2)
        {
            twoStringValue tsv;
            generatedCard = randomCard.Next(1, 52);
            tsv.s1 = player1C1 = generatedCard.ToString();
            tsv.s1 = player1C1 = player1C1 + ".png";
            return tsv;
        }
        /// <summary>
        /// Using a class
        /// </summary>
        class TwoStringValue
        {
            public string str1;
            public string str2;
        }
        public TwoStringValue PlayerCards(string player1C1, string player1C2)
        {
            TwoStringValue tsv;
            generatedCard = randomCard.Next(1, 52);
            tsv.str1 = player1C1 = generatedCard.ToString();
            tsv.str1 = player1C1 = player1C1 + ".png";
            return tsv;
        }

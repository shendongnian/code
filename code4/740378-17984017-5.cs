        void MyMethod()
        {
            decimal e = 2.71828;
            //     ^^^
            var sum = Enumerable.Range(1, 10)
                                .Sum(e => e * e); //Which "e" to multiply?
            //                      ^^^
        }

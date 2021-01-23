        public ulong Factorial(uint numb)
        {
            if (numb <= 1) return 1;
            ulong final = 1;
            for (uint i = 1; i <= numb; i++)
            {
                final *= i;
            }
            return final;
        }

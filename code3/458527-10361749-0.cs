       for (int i = 3; i <= 7; i++)
            {
                IsRishoni = true;
                for (int a = 2; (a <= Math.Sqrt(i)) && (IsRishoni); a++)
                {
                    if (i % a == 0)
                        IsRishoni = false;
                }
                if (IsRishoni)
                {
                    soap = i + soap;
                }
            }

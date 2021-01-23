            private void button1_Click(object sender, EventArgs e)
            {
                int a = 26500;
                int powerOfTen = (int)Math.Pow(10, NumDigits(a)-1);
                int lowerBound = a - a%powerOfTen;
                int upperBound = (a/powerOfTen + 1) * powerOfTen;
            }
            private int NumDigits(int value)
            {
                int count = 0;
                while (value > 0)
                {
                    value /= 10;
                    count++;
                }
                return count;
            }

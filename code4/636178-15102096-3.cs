    private void Form1_Load(object sender, EventArgs e)
            {
                string[] Colors = new string[] { "red", "orange", "yellow", "green", "blue", "purple" };
                string[] Foods = new string[] { "fruit", "grain", "dairy", "meat", "sweet", "vegetable" };
                Colors = Shuffle(Colors);
                Foods = Shuffle(Foods);
                Pair[] meal = new Pair[Colors.Count() - 1];
                for (int i = 0; i < Colors.Count() - 1; i++)
                {
                    meal[i] = new Pair(Colors[i],Foods[i]);
                }
            }
            static Random rdm = new Random();
            public string[] Shuffle(string[] c)
            {
                var random = rdm;
                for (int i = c.Length; i > 1; i--)
                {
                    int iRdm = rdm.Next(i);
                    string cTemp = c[iRdm];
                    c[iRdm] = c[i - 1];
                    c[i - 1] = cTemp;
                }
                return c;
            }
        }
        public class Pair
        {
             public string One;
             public string Two;
             public Pair(string m1, string m2)
             {
                 One = m1;
                 Two = m2;
             }
         }

        public class Farmer
        {
            private static int seed = 17;
            public decimal money { get; set; }
            public int FarmerID { get; set; }
            public Farmer(int id)
            {
                money = 100;
                FarmerID = id;
            }
            public void doOneYear() //Represents how much money the farmer earned
            {
                seed++;
                Random random = new Random(seed);
                decimal growth = random.Next(0, 100);
                decimal percentage = (growth / 1000);
                money = money * (1 + percentage);
            }
        }

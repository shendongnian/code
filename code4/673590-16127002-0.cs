    public class Farmer
    {
        public decimal money { get; set; }
        private static Random random = new Random();
        public Farmer()
        {
            money = 100;
        }
        public void doOneYear() //Represents how much money the farmer earned
        {
            decimal growth = random.Next(0, 100);
            decimal percentage = (growth / 1000);
            money = money * (1 + percentage);
        }
    }

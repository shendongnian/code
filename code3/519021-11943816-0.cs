    public class Logos : List<Logo> // Logo class can be anything, corresponds to your values
    {
        public Logos() 
        {
            Add(new Logo(true, "name1", "http://www.dreamland-recording.de", 1500)); // Item = name, 1500 = value
            Add(new Logo(true, "name2", "http://www.keller12.de", 3000));
            // etc
        }
        /// <summary>
        /// Returns a random logo based on donated money.
        /// </summary>
        /// <returns></returns>
        public Logo GetRandomLogo()
        {
            var sum = this.Sum(logo => logo.DonatedMoney); // DonatedMoney is your value
            var randomValue = new Random().Next(sum);
            // Iterate through logos until found.
            var found = false;
            var logoIndex = 0;
            var visitedValue = 0;
            while (!found)
            {
                var logo = this[logoIndex];
                if ((visitedValue + logo.DonatedMoney ) > randomValue)
                {
                    found = true;
                }
                else
                {
                    logoIndex++;
                    visitedValue += logo.DonatedMoney;
                }
            }
            return this[logoIndex]; // logo.Name contains your name.
        }

        public string NextId(int lastCount)
        {
            var rand = new Random();
            return string.Format("MA{0:0000000}/{1}/{2:00000}", 
                rand.Next(9999999),
                DateTime.Today.ToString("dd/MM/yyyy"),
                lastCount + 1);
        }

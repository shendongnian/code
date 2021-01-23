    class KitCollection : List<Kit>
    {
        public void FillData()
        {
            Random rnd = new Random();
            int i = 10; //let say 10 random data
            for (int j = 0; j < 10; j++)
            {
                Kit kit = new Kit();
                kit.CK_ID = rnd.Next(1, 100);
                this.Add(kit);
            }
        }
    }

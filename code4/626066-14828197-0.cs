    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            for(int i = 1; i < 20; i++)
            {
                try
                {
                    list.Capacity = 9;
                }
                catch (Exception)
                { button5.Enabled = false; }
                list.Add("teststring");
            }
            list = list;
        }
    }

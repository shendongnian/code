    public class Sample
    {
        public Sample()
        {
        }
        public string Size
        {
            get
            {
                int num=0;
                switch (index)
                {
                    case 0: num= 100;
                        break;
                    case 1: num= 500;
                        break;
                    case 2: num= 1000;
                        break;
                }
                return num;
            }
        }
    }

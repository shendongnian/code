     public Form1()
        {
            InitializeComponent();
            List<Sport> Sports = new List<Sport>();
            //create a swim object and give it some data
            Swimming swim1 = new Swimming();
            //create a cycle object and give it some data
            Cycling cycle1 = new Cycling();
            swim1.PH = 5;
            cycle1.BikeType = 2;
            // add the two objects to a list of base class
            Sports.Add(swim1);
            Sports.Add(cycle1);
            //iterate through the list of base class and cast the objects to their extended class
            //display a independent property of each just to prive it works.
            foreach (Sport s in Sports)
            {
                if (s is Cycling)
                {
                    MessageBox.Show(((Cycling)s).BikeType.ToString());
                }
                else if (s is Swimming)
                {
                    MessageBox.Show(((Swimming)s).PH.ToString());
                }
            }
        }
    }
    class Sport
    {
        DateTime DateAndTime = new DateTime();
    }
    class Swimming : Sport
    {
        public int PH = 0;
        public int temperature = 0;
    }
    class Cycling : Sport
    {
        public int BikeType = 1;
        public int TireSize = 26;
    }

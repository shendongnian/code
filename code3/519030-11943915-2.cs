        const double Item100 = 10000 / 6820000d;  // force double 
        const double Item75 = 300000 / 6820000d;  // otherwise all  
        const double Item50 = 2000000 / 6820000d; // values would
        const double Item25 = 1500000 / 6820000d; // be zero
 
        int getRandomItem(Random rnd)
        {
            double value = rnd.NextDouble();
            if (value <= Item100)
            {
                // use one of both possible items (100 or 150)
                int which = rnd.Next(0, 2);
                return which == 0 ? 100 : 150;
            }
            else if (value <= Item75)
                return 75;
            else if (value <= Item50)
                return 50;
            else if (value <= Item25)
                return 25;
            else
                return 0;
        }

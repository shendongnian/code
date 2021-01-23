    public static float Charge(int lengthInMinutes)
        {
            float charge = 0.0f;
            while (lengthInMinutes >= 60)
            {
                charge += 2;
                lengthInMinutes -= 60;
            }
            // at this point, we'll only have less than 60 minutes
            if (lengthInMinutes > 30)
            {
                charge += 2;
            }
            else if (lengthInMinutes > 0)
            {
                charge += 1;
            }
            if (charge > float.MaxValue)
                return float.MaxValue;
            return charge;
        }

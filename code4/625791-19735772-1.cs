            if (change >= 100)
            {
                decimal rand = change / 100;
                hundred= (int)rand;
                change = change % 100;
            }
            if (change >= 50)
            {
                decimal rand = (int)change / 50;
                fifty = (int)rand;
                change = change % 50;
            }
            if (change >= 20)
            {
                decimal rand = change / 20;
                twenty = (int)rand;
                change = change % 20;
            }
         

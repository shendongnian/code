        void MyMethod()
        {
            decimal e = 2.71828;
            //     ^^^
       
            try
            {
                DoSomething();
            }
            catch (Exception e)
            //              ^^^
            {
                OhNo(e);
                // Which "e" is this? Is it the Exception or the Decimal??
            }
        }

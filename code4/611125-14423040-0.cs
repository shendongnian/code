            bool isFirstTime = true;
            DateTime localVarToBeAssigned;
            while (true)
            {
                if (isFirstTime)
                {
                    isFirstTime = false;
                }
                else
                {
                    // this reads the variable
                    Console.WriteLine(localVarToBeAssigned);
                }
                // this assigns the variable
                localVarToBeAssigned = DateTime.Now;
            }

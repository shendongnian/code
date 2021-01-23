        public void addTest(Test a)
        {
           for (int i = 0; i < myTests.Length; i++)
           {
               if (myTests[i] == null)
               {
                   //Adds test and leaves loop.
                   myTests[i] = a;
                   break;
               }
               //Handler for if all tests are already populated.
               if (i == myTests.Length)
               {
                   MessageBox.Show("All tests full.");
               }
            }
        }

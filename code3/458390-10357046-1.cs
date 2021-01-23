     for (int numTests = 0; numTests < 20; numTests++)
            {
                using (AutomatedTest test1 = new AutomatedTest(TestList._1DayTest))
                {
                    RunAutoTest(test1);
                }
                //as soon as code exits the 'using' block the dispose method on test1 would be called
                //this is something you cannot guarantee when implementing a destructor
                using (AutomatedTest test2 = new AutomatedTest(TestList._2DayTest))
                {
                    RunAutoTest(test2);
                }
                //dispose on test2 will be called here
                ///rest of code
            }  

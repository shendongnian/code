        void MyEventHandler(object source, EventArgs e)
        //                                          ^^^
        {
            try
            {
                DoSomething();
            }
            catch (Exception e)
            //              ^^^
            {
                OhNo(e);
                // Which "e" is this? Is it the Exception or the EventArgs??
            }
        }

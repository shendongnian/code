    public void EndApp ()
        {
            this.testButton.Title="Closing App";
            Application.DoEvents();
            //long time process
            for (int i = 0; i < 1000000; i++) {
                int a=1;
                //or if you're processing stuff
                Application.DoEvents();
            }
        }

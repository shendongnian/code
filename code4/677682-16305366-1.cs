    A aObject = new A();
            Thread aThread = new Thread(aObject.startA);
            while (!aObject.AIsReady)
            {
                Thread.Sleep(100);
            }
            MessageBox.Show("A is Ready");

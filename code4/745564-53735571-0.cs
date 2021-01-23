    void MyFunc()
        {
            Watcher watcher = new Watcher();
            //Some call
            HightLoadFunc();
            watcher.Tick("My high load tick 1");
            SecondFunc();
            watcher.Tick("Second tick");
            Debug.WriteLine(watcher.Result());
            //Total: 0.8343141s; My high load tick 1: 0.4168064s; Second tick: 0.0010215s;
        }

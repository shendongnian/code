            EventWaitHandle signal = new EventWaitHandle(initialState: false, mode: EventResetMode.ManualReset);
            ThreadStart action = () => {
                signal.WaitOne();
                var result = factory.Hello("Eduard");
                Console.WriteLine(result);
            };
            foreach (var i in Enumerable.Range(0, 99))
                new Thread(action) { IsBackground = true }.Start();

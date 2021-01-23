        private void button2_Click(object sender, EventArgs e)
        {
            Task.Run(() => loop());
            using (PerformanceCounter pc = new PerformanceCounter("TestCounters", "RateTest", true))
            {
                CounterSample a = pc.NextSample();
                while (true)
                {               
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(5000);
                    CounterSample b = pc.NextSample();
                    Single deltaTime = Convert.ToSingle(b.CounterTimeStamp / b.CounterFrequency - a.CounterTimeStamp/a.CounterFrequency);
                    Single deltaRaw = Convert.ToSingle(b.RawValue - a.RawValue);
                    label1.Text = (deltaRaw / deltaTime).ToString();
                    b = a;
                }
            }
        }
        private void loop()
        {
            while (true)
            {
                using (PerformanceCounter pc = new PerformanceCounter("TestCounters", "RateTest", false))
                {
                    pc.Increment();
                }
                System.Threading.Thread.Sleep(250);
            }
        }

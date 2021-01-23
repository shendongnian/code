    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car();
            car.Stopped += car_Stopped;
            var evt = car.GetType().GetEvent("Stopped");
            if(evt == null) //evt will be null if nothing is registered to the event
                car.Stopped += car_Stopped;
            car.Stop(); //Prints 'Stopped!' only once
            Console.ReadLine();
        }
        static void car_Stopped(object sender, EventArgs e)
        {
            Console.WriteLine("Stopped!");
        }
    }
    class Car
    {
        public event EventHandler<EventArgs> Stopped;
        protected void OnStopped()
        {
            var temp = Stopped;
            if(temp != null)
                Stopped(this, new EventArgs());
        }
        public void Stop()
        {
            OnStopped();
        }
    }

    using System;
    using System.Threading;
    namespace Demo
    {
        class Program
        {
            private void run()
            {
                int numberOfHorses = 12;
                // Use a barrier with a participant count that is one more than the
                // the number of threads. The extra one is for the main thread,
                // which is used to signal the start of the race.
                Barrier barrier = new Barrier(numberOfHorses + 1);
                var horsesThreads = new Thread[numberOfHorses];
                for (int i = 0; i < numberOfHorses; i++)
                {
                    int horseNumber = i;
                    horsesThreads[i] = new Thread(() => runRace(horseNumber, barrier));
                    horsesThreads[i].Start();
                }
                Console.WriteLine("Press <RETURN> to start the race!");
                Console.ReadLine();
                // Signals the start of the race. None of the threads that called
                // SignalAndWait() will run until all the participants have signalled
                // the barrier.
                barrier.SignalAndWait();
                Console.WriteLine("Race started!");
                Console.ReadLine();
            }
            private static void runRace(int horseNumber, Barrier barrier)
            {
                Console.WriteLine("Horse " + horseNumber + " is waiting to start.");
                barrier.SignalAndWait();
                Console.WriteLine("Horse " + horseNumber + " has started.");
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }

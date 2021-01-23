    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ThrottledAsync
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Queue up multiple user actions
                // within a short interval.
                for (var i = 0; i < 10; i++)
                {
                    OnUserAction();
                    Thread.Sleep(10);
                }
                Console.ReadLine();
            }
            private static int UserActionID;
            private static DateTime previousWaitStartTime;
            public static async void OnUserAction()
            {
                // Keep track of the operation ID.
                var userActionID = Interlocked.Increment(ref UserActionID);
                // Pseudo-code implementation.
                var timeUntilPreviousCallWillBeOrWasMade = 1000 - (int)(DateTime.Now.Subtract(previousWaitStartTime).TotalMilliseconds);
                Console.WriteLine(
                    "{0:HH:mm:ss.ffff} - User action {1}: timeUntilPreviousCallWillBeOrWasMade = {2}.",
                    DateTime.Now, userActionID, timeUntilPreviousCallWillBeOrWasMade);
                var timeToWaitBeforeThisCallShouldBeMade = Math.Max(0, timeUntilPreviousCallWillBeOrWasMade + 1000);
                Console.WriteLine(
                    "{0:HH:mm:ss.ffff} - User action {1}: timeToWaitBeforeThisCallShouldBeMade = {2}.",
                    DateTime.Now, userActionID, timeToWaitBeforeThisCallShouldBeMade);
                previousWaitStartTime = DateTime.Now;
                await Task.Delay(timeToWaitBeforeThisCallShouldBeMade);
                await MakeCallToWebService(userActionID);
            }
            private static async Task MakeCallToWebService(int userActionID)
            {
                // Simulate network delay.
                await Task.Delay(new Random().Next(5, 10));
                Console.WriteLine("{0:HH:mm:ss.ffff} - User action {1}: web service call.", DateTime.Now, userActionID);
            }
        }
    }

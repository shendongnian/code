            var original = DateTime.Now;
            var newTime = original;
            var waitTime = 10;
            int remainingWaitTime = waitTime;
            var lastWaitTime = waitTime.ToString();
            var keyRead = false;
            Console.Write("Waiting for key press or expiring in " + waitTime);
            do
            {
                keyRead = Console.KeyAvailable;
                if (!keyRead)
                {
                    newTime = DateTime.Now;
                    remainingWaitTime = waitTime - (int) (newTime - original).TotalSeconds;
                    var newWaitTime = remainingWaitTime.ToString();
                    if (newWaitTime != lastWaitTime)
                    {
                        for (int i = 0; i < lastWaitTime.Length; i++)
                        {
                            Console.Write("\b \b");
                        }
                        lastWaitTime = newWaitTime;
                        Console.Write(lastWaitTime);
                        Thread.Sleep(25);
                    }
                }
            } while (remainingWaitTime > 0 && !keyRead);

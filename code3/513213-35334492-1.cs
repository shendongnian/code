            var original = DateTime.Now;
            var newTime = original;
            var waitTime = 10;
            var remainingWaitTime = waitTime;
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
                        var backSpaces = new string('\b', lastWaitTime.Length);
                        var spaces = new string(' ', lastWaitTime.Length);
                        Console.Write(backSpaces + spaces + backSpaces);
                        lastWaitTime = newWaitTime;
                        Console.Write(lastWaitTime);
                        Thread.Sleep(25);
                    }
                }
            } while (remainingWaitTime > 0 && !keyRead);

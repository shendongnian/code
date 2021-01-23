	/// <summary>
	/// Waits until an element of the type <paramref name="element"/> to show in the screen.
	/// </summary>
	/// <param name="element">Element to be waited for.</param>
	/// <param name="timeout">How long (in seconds) it should be waited for.</param>
	/// <returns>
	/// False: Never found the element. 
	/// True: Element found.
	/// </returns>
	private bool WaitElement(By element, int timeout)
	{
		try {
			Console.WriteLine($" - Waiting for the element {element.ToString()}");
			int timesToWait = timeout * 4; // Times to wait for 1/4 of a second.
			int waitedTimes = 0; // Times waited.
			// This setup timesout at 7 seconds. you can change the code to pass the 
			do {
				waitedTimes++;
				if (waitedTimes >= timesToWait) {
					Console.WriteLine($" -- Element not found within (" +
					$"{(timesToWait * 0.25)} seconds). Canceling section...");
					return false;
				}
				Thread.Sleep(250);
			} while (!ExistsElement(element));
			Console.WriteLine($" -- Element found. Continuing...");
		//  Thread.Sleep(1000); // may apply here
			return true;
		} catch { throw; }
	}

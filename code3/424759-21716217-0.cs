    static ManualResetEvent resetEvent = new ManualResetEvent(true);
    /// <summary>
    /// Resets the ReadKey function from another thread.
    /// </summary>
    public static void ReadKeyReset()
    {
        resetEvent.Set();
    }
    /// <summary>
    /// Reads a key from stdin
    /// </summary>
    /// <returns>The ConsoleKeyInfo for the pressed key.</returns>
    /// <param name='intercept'>Intercept the key</param>
    public static ConsoleKeyInfo ReadKey(bool intercept = false)
    {
        resetEvent.Reset();
        while (!Console.KeyAvailable)
        {
            if (resetEvent.WaitOne(50))
                throw new GetKeyInteruptedException();
        }
        int x = CursorX, y = CursorY;
        ConsoleKeyInfo result = CreateKeyInfoFromInt(Console.In.Read(), false);
        if (intercept)
        {
            // Not really an intercept, but it works with mono at least
            if (result.Key != ConsoleKey.Backspace)
            {
                Write(x, y, " ");
                SetCursorPosition(x, y);
            }
            else
            {
                if ((x == 0) && (y > 0))
                {
                    y--;
                    x = WindowWidth - 1;
                }
                SetCursorPosition(x, y);
            }
        }
        return result;
    }

    timer.Start();
    using (var stream = new StreamWriter(Console.OpenStandardOutput()))
    {
        for (int i = 0; i < testSize; i++)
        {
            Test4("just a little test string.", stream);
        }
    }
    timer.Stop();

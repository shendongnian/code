    using (Tracer tracer = new Tracer("General"))
    {
        FieldInfo fieldInfo = typeof(Tracer).GetField("stopwatch", BindingFlags.NonPublic | BindingFlags.Instance);
        var sw = fieldInfo.GetValue(tracer) as Stopwatch;
        Console.WriteLine(sw.ElapsedMilliseconds);
    }

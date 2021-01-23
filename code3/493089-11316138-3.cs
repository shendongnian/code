    Debug.WriteLine("lWords.Count hWords.Count " + lWords.Count.ToString() + " " + hWords.Count.ToString());
    Stopwatch SW = new Stopwatch();
    SW.Start();
    Debug.WriteLine("L count " + lWords.Where(value => value.StartsWith("s")).Count().ToString());
    SW.Stop();
    Debug.WriteLine("L time " + SW.ElapsedMilliseconds.ToString());
    sw.Reset();
    SW.Start();
    Debug.WriteLine("H count " + hWords.Where(value => value.StartsWith("s")).Count().ToString());
    SW.Stop();
    Debug.WriteLine("H time " + SW.ElapsedMilliseconds.ToString());
    sw.Reset();
    SW.Start();
    Debug.WriteLine("L count " + lWords.AsParallel().Where(value => value.StartsWith("s")).Count().ToString());
    SW.Stop();
    Debug.WriteLine("L time parallel " + SW.ElapsedMilliseconds.ToString());
    sw.Reset();
    SW.Start();
    Debug.WriteLine("H count " + hWords.AsParallel().Where(value => value.StartsWith("s")).Count().ToString());
    SW.Stop();
    Debug.WriteLine("H time parallel " + SW.ElapsedMilliseconds.ToString());
    Output:
    lWords.Count hWords.Count 667309 667309
    L count 45851
    L time 267
    H count 45851
    H time 559
    L count 45851
    L time parallel 900
    H count 45851
    H time parallel 1210

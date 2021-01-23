    Debug.WriteLine("lWords.Count hWords.Count " + lWords.Count.ToString() + " " + hWords.Count.ToString());
    Stopwatch SW = new Stopwatch();
    SW.Restart();
    Debug.WriteLine("H count " + hWords.Where(value => value.StartsWith("s")).Count().ToString());
    SW.Stop();
    Debug.WriteLine("H time " + SW.ElapsedMilliseconds.ToString());
    SW.Restart();
    SW.Stop();
    Debug.WriteLine("Start Stop " + SW.ElapsedMilliseconds.ToString());
    SW.Restart();
    Debug.WriteLine("L count " + lWords.Where(value => value.StartsWith("s")).Count().ToString());
    SW.Stop();
    Debug.WriteLine("L time " + SW.ElapsedMilliseconds.ToString());
    SW.Restart();
    Debug.WriteLine("H count " + hWords.Where(value => value.StartsWith("s")).Count().ToString());
    SW.Stop();
    Debug.WriteLine("H time " + SW.ElapsedMilliseconds.ToString());
    SW.Restart();
    Debug.WriteLine("L count " + lWords.AsParallel().Where(value => value.StartsWith("s")).Count().ToString());
    SW.Stop();
    Debug.WriteLine("L time parallel " + SW.ElapsedMilliseconds.ToString());
    SW.Restart();
    Debug.WriteLine("H count " + hWords.AsParallel().Where(value => value.StartsWith("s")).Count().ToString());
    SW.Stop();
    Debug.WriteLine("H time parallel " + SW.ElapsedMilliseconds.ToString());
    Debug.WriteLine("");
    output:
    lWords.Count hWords.Count 667309 667309
    H count 45851
    H time 283
    Start Stop 0
    L count 45851
    L time 285
    H count 45851
    H time 364
    L count 45851
    L time parallel 307
    H count 45851
    H time parallel 344

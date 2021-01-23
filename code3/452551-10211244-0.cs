    // TODO: add using System.Diagnostics;
    // on a class level
    Stopwatch watch;
    // once in constructor
    this.watch = new Stopwatch();
    // in measurement method
    this.watch.Restart();
    session.Read(null, 0, TimestampsToReturn.Neither, idCollection, 
                 out ReadResults, out diagnosticInfos);
    
    watch.Stop();
    double s = watch.ElapsedMilliseconds; 

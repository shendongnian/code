    public class JobImplement : IJob, IDisposable
    {
     public void Dispose()
        {
            Trace.WriteLine("JobImplement.Dispose()");
        }
    }

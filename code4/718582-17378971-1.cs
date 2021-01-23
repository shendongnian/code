    private sealed class DelayPromise : Task<VoidTaskResult>
    {
      internal readonly CancellationToken Token;
      internal CancellationTokenRegistration Registration;
      internal Timer Timer;
      internal DelayPromise(CancellationToken token)
      {
        this.Token = token;
      }
      internal void Complete()
      {
        if (!(this.Token.IsCancellationRequested ? this.TrySetCanceled(this.Token) : this.TrySetResult(new VoidTaskResult())))
          return;
        if (this.Timer != null)
          this.Timer.Dispose();
        this.Registration.Dispose();
      }
    }

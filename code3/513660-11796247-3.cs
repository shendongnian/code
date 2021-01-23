    public class NoUnmanaged : IDisposable
    {
      private HandlesUnmanaged _likeAbove;
      private Stream _anExampleDisposableClass;
      public virtual void Dispose()
      {
        _likeAbove.Dispose();
        _anExampleDisposableClass.Dispose();
      } 
      /* Note no finaliser, if Dispose isn't called, then _likeAbove's
      finaliser will be called anyway. All a finaliser here would do is
      slow things up and possibly introduce bugs.
      */
    }
    public class DerivedNoUnManaged : NoUnmanaged
    {
      Stream _weMayOrMayNotHaveAnotherDisposableMember;
      public override void Dispose()
      {
        //note we only need this because we have
        //another disposable member. If not, we'd just inherit
        //all we need.
        base.Dispose();
        weMayOrMayNotHaveAnotherDisposableMember.Dispose();
      }
    }

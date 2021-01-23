    public class TestService
    {
         public IObservable<int> GetObservable(int max)
         {
             return Observable.Create<int>((IObserver<int> observer) =>
                                   {
                                       for (int i = 0; i < max; i++)
                                       {
                                           observer.OnNext(i);
                                       }
                                       observer.OnCompleted();
                                   });
         }
    }

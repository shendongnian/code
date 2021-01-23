    class Foo<TWhat, TFine> : Bar, IWhatever, IFine
        where TWhat : IWhatever, new()
        where TFine : IFine, new()
    {
       IWhatever mWhatever;
       IFine mFine;
       Foo()
       {
          mWhatever = new TWhat();
          mFine = new TFine();
       }
       // from IWhatever
       public void Kick()
       {
          mWhatever.Kick();
       }
       // from IFine
       public void Punch()
       {
          mFine.Punch();
       }
    }
This way, Foo can be made to use any classes which implement IWhatever and IFine, not just Whatever and Fine.

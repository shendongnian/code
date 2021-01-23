    public  interface   IComposite<TIComposite, TIMixin1, TIMixin2>
            where       TIComposite : class,    IComposite<TIComposite, TIMixin1, TIMixin2>, TIMixin1, TIMixin2
            where       TIMixin1    : class
            where       TIMixin2    : class
    {
        public  class   Composer
        {
            public  static  TIComposite     Create(TIMixin1 mixin1, TIMixin2 mixin2)
            {
                ...
            }
        }
    }

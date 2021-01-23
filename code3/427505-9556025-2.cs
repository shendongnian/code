    public class ObservableHelper<T>
        where T : class //or EntityObject 
    {
        public ObservableHelper()
        {
            _dat = new PdvEntities();
        }
        PdvEntities _dat;
        public IObservable<IList<T>> GetAllAsObservables
                                    (Func<PdvEntities, IQueryable<T>> funcquery)
        {
            var getall = Observable.ToAsync<PdvEntities, IQueryable<T>>(funcquery);
            return getall(_dat).Select(x => x.ToList());
        }
    }

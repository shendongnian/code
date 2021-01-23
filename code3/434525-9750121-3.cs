    public List<TResult> FindAll<TResult>(Func<Regions, TResult> selector) where TResult : class
        {
            using (RepositoryDataContext = new DataClasses1DataContext())
            {
                    return RepositoryDataContext.Regions.Select<Regions, TResult>(selector).ToList<TResult>();
                
            }
        }

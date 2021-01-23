    public abstract class RepositoryBase<T, TDb> : where T : new() where TDb : class, new()
    {
        protected IQueryable<T> GetBy(Expression<Func<TDb, bool>> where = null,
                                      PagingSortOptions? pagingSortOptions = null)
        {
            //GetDbSet basic method to get DbSet in generic way 
            IQueryable<TDb> query = GetDbSet();
            if (where != null)
            {
                query = query.Where(where);
            }
            
            if (pagingSortOptions != null)
            {
                query = query.InjectPagingSortQueryable(pagingSortOptions);
            }
            return query.Select(GetConverter());
        }
        protected virtual Expression<Func<TDb, T>> GetConverter()
        {
            return dbEntity => Mapper.Map<TDb, T>(dbEntity);
        }
    }
    public class CountryRepository : RepositoryBase<CountryDomainModel, CountryDb>, ICountryRepository
    {
        public Country GetByName(string countryName)
        {
            return GetBy(_ => _.Name == countryName).First();
        }
    }
    public interface ICountryRepository : IRepository<CountryDomainModel>
    {
        Country GetByName(string countryName);
    }
    public interface IRepository<TDomainModel>
    {
        //some basic metods like GetById
    }

    public class Category
    {
        public virtual int Id { set; get; }
        public virtual string Name { set; get; }
        public virtual int CategoryOrder { set; get; }
        public virtual IEnumerable<News> AllNews { set; get; }
        public virtual News LatestNews 
        {
            get
            {
                // probably needs some work
                return this.AllNews.OrderByDescending(n => n.SomeDateField).Take(1);
            }
        }
    }
    public sealed class CategoryMap :ClassMap<Category>
    {
    
        public CategoryMap()
        {
            LazyLoad();
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.CategoryOrder);
            HasMany(x => x.AllNews);
        }
    
    }

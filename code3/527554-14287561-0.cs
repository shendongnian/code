    <add name="MovieDBContext"  ....... />
    public class MovieDBContext : DbContext
    {
       public MovieDBContext() : base("Movie") { }
    }

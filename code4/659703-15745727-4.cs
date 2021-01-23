    public interface ILanguageAware
    {
        string CurrentLanguage { get; }
        string English { get; }
        string French { get; }
        string German { get; }
    }
    public class ObjectWithLanguage<T> where T : ILanguageAware
    {
        public T OriginalObject { get; set; }
        string LanguageText { get; set; }
    }
    public Expression<Func<T, ObjectWithLanguage<T>>> GetObjectWithLanguage<T>() where T : ILanguageAware
    {
        return x => new ObjectWithLanguage<T>
               {
                   OriginalObject = x,
                   LanguageText = x.CurrentLanguage == "de" ? x.German :
                                  x.CurrentLanguage == "fr" ? x.French :
                                  ...
               }
    }
    // extension method for convenience
    public static IQueryable<ObjectWithLanguage<T>> SelectWithLanguage<T>(this IQueryable<T> queryable)
    {
        return queryable.Select(GetObjectWithLanguage<T>());
    }
    var results = context.Objectss.Where(e => e.Id == myId).SelectWithLanguage();

c#
public IEnumerable<T> GetItems<T>(string userId) where T : class, IDbEntity
{
    var query = db.Set<T>().Where(l => l.UserId==userId);
    var props = Util.GetInverseProperties<T>();
    foreach (var include in props)
        query = query.Include(include.Name);
    return query
        .AsNoTracking()
        .ToList();
}
c#
public interface IDbEntity
{
    public string UserId { get; set; }
}
c#
public static List<PropertyInfo> GetInverseProperties<T>()
{
    return typeof(T)
        .GetProperties()
        .Where(p => Attribute.IsDefined(p, typeof(InversePropertyAttribute)))
        .ToList();
}

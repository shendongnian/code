    var query = from u in context.Users select u;
    var pred = Predicate.False<User();>
    if (type.HasFlag(IdentifierType.Username))
        pred = pred.Or(u => u.Username == identifier);
    if (type.HasFlag(IdentifierType.Windows))
        pred = pred.Or((u => u.WindowsUsername == identifier);
    return query.Where(pred.Expand()).FirstOrDefault();
    // or return query.AsExpandable().Where(pred).FirstOrDefault();

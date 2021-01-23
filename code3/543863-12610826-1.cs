    public static T Read<T>(Expression<Func<T,bool>> pred) {
        using (ISession session = NHibernateHelper.OpenSession()) {
            return session.Query<T>().SingleOrdefault(pred);
        }
    }

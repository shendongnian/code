    public static class MyDbContextStatic { 
        public static T Execute(Func<MyDbContext, T> f) {
            using (var db = new MyDbContext())
                return f(db);
        }
    }

        private static Dictionary<Tuple<Type, Type>, Func<object>> _map = new Dictionary<Tuple<Type, Type>, Func<object>>();
        public static MigrateDatabaseToLatestVersion<TContext, TMigrationsConfiguration> CreateMigrateDatabaseToLatestVersion<TContext, TMigrationsConfiguration>(TContext type, TMigrationsConfiguration configuration)
        {
            Type contextType = typeof (TContext);
            Type configurationType = typeof(TMigrationsConfiguration);
            Func<object> builder;
            if (!_map.TryGetValue(new Tuple<Type, Type>(contextType, configurationType), out builder))
                throw new KeyNotFoundException();
            return (MigrateDatabaseToLatestVersion<TContext, TMigrationsConfiguration>)builder();
        }

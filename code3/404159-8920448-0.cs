        public static UnitOfWork Init<T1>()
        {
            UnitOfWork uow = new UnitOfWork();
            uow.Add(new Repository<T1>());
            return uow;
        }
        public static UnitOfWork Init<T1,T2>()
        {
            UnitOfWork uow = Init<T1>();
            uow.Add(new Repository<T2>());
            return uow;
        }
        public static UnitOfWork Init<T1, T2, T3>()
        {
            UnitOfWork uow = Init<T1,T2>();
            uow.Add(new Repository<T3>());
            return uow;
        }
        // ...

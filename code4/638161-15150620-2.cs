        public override void Load()
        {
            Bind(typeof(IUserRepository)).To(typef(UserRepository));
            Bind(typeof(IMyContext)).To(typeof(MyContext));
            ...
        }

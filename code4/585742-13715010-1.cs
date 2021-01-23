            using (var uow = new UnitOfWorkUser(new Context()))
            {
                using (var _userRepo = new UserRepository(uow))
                {
                    _userRepo.InsertOrUpdate(newUser);
                    uow.Save();
                }
            }

    public class MyUserService {
        public User GetById(int id) {
            try {
                using(var ctx = new ModelContainer()) {
                    return ctx.Where(u => u.Id == id).Single();
                }
            }
            catch(InvalidOperationException) {
                // OOPs, there is no user with the given id!
                throw new UserNotFoundException(id);
            }
        }
    }

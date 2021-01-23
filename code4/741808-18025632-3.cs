    public class Service
    {
        public User AddOrUpdateUser(User user)
        {
            var method = WebOperationContext.Current.IncomingRequest.Method.ToUpperInvariant();
            if (method != "POST" || method != "PUT")
            {
                throw new WebFaultException(HttpStatusCode.MethodNotAllowed);
            }
            if (user == null)
                throw new ArgumentNullException("user", "AddOrUpdateUser: user is null");
    
            using (var context = new AdnLineContext())
            {
                context.Entry(user).State = user.UserId == 0 ?
                                            EntityState.Added :
                                            EntityState.Modified;
                context.SaveChanges();
            }
    
            return user;
        }
    }

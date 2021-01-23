    [WebMethod(true)]
    public static object ParentLogin(string email, string password)
    {
        return ServiceAdapter.ParentLogin(email, password);
    }
    public interface IService
    {
        object ParentLogin(string email, string password);
    }
    public sealed class Service : IService
    {
        public object ParentLogin(string email, string password)
        {
            List<object> ChildrenList = new List<object>();
            Usuario loggedUser = GetByEmailAndPass(email, password);
            if (loggedUser != null)
            {
                var children = Factory.Current.GetInstance<IChildrenBIZ>().GetAll().ToList();
                foreach (var item in children )
                {
                    ChildrenList.Add(new { userid = item.Id, name = item.Nome });
                }
                return new { success = true, email = loggedUser.Login, users = ChildrenList};
            }
            return new { success = false };
        }
        
        //TODO move GetByEmailAndPass
    }
    public sealed class ServiceAdapter
    {
        public static readonly IService Service = new Service();
    }

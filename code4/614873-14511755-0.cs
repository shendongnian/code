    public class UserProfileRepository&#60;TUserProfile&#62; : IEntityRepository&#60;TUserProfile&#62; where TUserProfile : IUserProfile
    {
       private Namespace.DAL.UserProfileRepository _rep = new Namespace.DAL.UserProfileRepository();
    
       public TUserProfile[] GetAll()
       {
         return _rep.GetAll();
       }
    
       public TUserProfile GetById(int id)
       {
         return _rep.GetById(id);
       }
    
       public IQueryable&#60;TUserProfile&#62; Query(Expression&#60;Func&#60;TUserProfile, bool&#62;&#62; filter)
       {
         return _rep.Query(filter);
       }
    }

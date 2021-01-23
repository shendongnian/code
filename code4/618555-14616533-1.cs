    namespace XYZ.DAL
    {
    public class LuwBosMaster : Luw, ILuwBosMaster
    {
        public LuwBosMaster(DbContext context, IBosCurrentState currentState)  
        {
           base.Initialise(context,currentState); 
        }
        public LuwBosMaster()
        {
            base.Initialise(GetDefaultContext(), BosGlobal.BGA.IBosCurrentState);
        }
        public static DbContextBosMaster GetDefaultContext()
        {
         return new DbContextBosMaster("BosMaster");
        }
        //MasterUser with own Repository Class
        private IRepositoryMasterUser _repositoryMasterUser;
        public  IRepositoryMasterUser RepMasterUser
        { get { return _repositoryMasterUser ?? (_repositoryMasterUser = new RepositoryMasterUser(Context, CurrentState)); } }
     
        //20 other repositories declared adn available within this Luw
        // Some repositories might address several tables other single tables only.
        //  The repositories are based on a base class that common generic behavior for each MODEL object

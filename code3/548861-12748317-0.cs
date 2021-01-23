    public class SomeService
    {
        private readonly IRepositoryA _repoA;
        private readonly IRepositoryB _repoB;
        public void DoStuff(EntityA someEntityA, EntityB someEntityB)
        {
            try 
            {
                 _repoA.Save(someEntityA);
                 _repoB.Save(someEntityB);
                 // commit all stuff here
            }
            catch
            {
                 // rollback all stuff here
            }
        }
    }

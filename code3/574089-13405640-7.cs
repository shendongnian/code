    public class FakePonyRepositoryThatOnlyReturnsBrownPonies : IRepository<Pony>
    {
        private List<Pony> _verySpecificAndNotReusableListOfOnlyBrownPonies = new List....
        public IEnumerable<Pony> GetAll()
        {
            return _verySpecificAndNotReusableListOfOnlyBrownPonies;
        }
    }
    public class FakePonyRepositoryThatThrowsExceptionFromGetAll : IRepository<Pony>
    {
        public IEnumerable<Pony> GetAll()
        {
            throw new OmgNoPoniesException();
        }
    }

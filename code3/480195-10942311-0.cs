    public class PersonBLL : IBussiness<PersonVO>
    {
        public List<PersonVO> CreateNewList() { ... }
        public List<PersonVO> GetAll<PersonVO>()
        {
            return CreateNewList();
        }
    }

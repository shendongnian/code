    class EntityHandler
    {
        FirstClass firstClass = new FirstClass();
        public IEntity RetrieveEntity(int userParam)
        {
            return firstClass.GetEntity(userParam);
        }
        public IEntity RetrieveEntity(string userParam)
        {
            return firstClass.GetEntity(userParam);
        }
    }

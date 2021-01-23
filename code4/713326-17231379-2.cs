    class EntityHandler<T>
    {
        public IEntity RetrieveEntity (T userParam)
        {
            if(userParam is int)
               return firstClass.GetEntity((int)(object)userParam)
            else if(userParam is string)
               return firstClass.GetEntity((string)(object)userParam)
            else 
               // add your code here
        }
    }

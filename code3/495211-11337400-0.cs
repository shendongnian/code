    private List<T> get<T>()
        {
            List<IEntity> list = new List<IEntity>();
            List<T> genericList = new List<T>();
            foreach (var item in list)
            {
                genericList.Add((T)item);
            }
            return genericList;
        }

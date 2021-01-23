    public List <T> GetCollection<T>() where T :Item
            {
    
                if (typeof(T) == typeof(Game))
                {
                    return _games.Cast<T>().ToList();
                }
                if (typeof(T) == typeof(Music))
                {
                    return _musics.Cast<T>().ToList(); ;
                }
            return null;
            }

     public string Name(int index)
        {
            if (index >= 0 && index < Players.Count())
                return Players.ElementAt(index);
            else
                return null;
        }

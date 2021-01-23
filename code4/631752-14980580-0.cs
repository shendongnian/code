    List<string> fruitsList = new List<string>();
    public List<string> FruitsList
    {
        get
        {
            return fruitsList;
        }
    }
    public string Fruits
    {
        get
        {
            return string.Join(',', fruitsList);
        }
        set
        {
            // Incomplete, does not handle null
            FruitsList.Clear();
            FruitsList.AddRange(value.Split(','));
        }
    }

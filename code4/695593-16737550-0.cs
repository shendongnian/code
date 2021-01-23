    foreach (KeyValuePair<string, object> keyValuePair in items)
    {
        if (keyValuePair.Key == "animals")
        {
            Dictionary<string, object> animal = new Dictionary<string, object>();
            animal.Add(keyValuePair.Key, keyValuePair.Value);
            IEnumerable animalObject = keyValuePair.Value as IEnumerable;
            
            if(animalEnumerable != null)
            {
                foreach (object animalObj in animalEnumerable)
                {
                }
            }
        }
    }

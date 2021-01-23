    public void CompareTwoObjectsAndSaveChanges<TObjectType>(TObjectType objectA, TObjectType objectB )
        {
            foreach (var prop in typeof(TObjectType).GetProperties())
            {
                if(prop.GetValue(objectA, null) != prop.GetValue(objectB, null))
                {
                    string nameOfPropertyThatChanges = prop.Name;
                    string objectAValue = prop.GetValue(objectA, null).ToString();
                    string objectBValue = prop.GetValue(objectB, null).ToString();
                    //logic to save to database
                }
            }   
        }

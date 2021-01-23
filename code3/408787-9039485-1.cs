    public void CompareTwoObjectsAndSaveChanges<TObjectType>(TObjectType objectA, TObjectType objectB )
        {
            //makes sure both objects match in Type
            if(objectA.GetType() == objectB.GetType())
            {
               //uses reflection to get all the properties of that object.
               foreach (var prop in objectA.GetType().GetProperties())
               {
                   //checks to see if the value is different
                   if(prop.GetValue(objectA, null) != prop.GetValue(objectB, null))
                   {
                       //get the property name and its two different values
                       string nameOfPropertyThatChanges = prop.Name;
                       string objectAValue = prop.GetValue(objectA, null).ToString();
                       string objectBValue = prop.GetValue(objectB, null).ToString();
                       //logic to save to database
                   }
               }   
            }
        }

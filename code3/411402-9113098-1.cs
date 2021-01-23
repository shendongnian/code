    public void CompareTwoObjectsAndSaveChanges<TObjectType>(TObjectType objectA, TObjectType objectB )
    {
        if(objectA.GetType() == objectB.GetType())
        {
           foreach (var prop in objectA.GetType().GetProperties())
           {
               if(prop.GetValue(objectA, null) != prop.GetValue(objectB, null))
               {
    	           // Get the column attribute
    		       ColumnAttr attr = (ColumnAttr)objectA.GetType().GetCustomAttributes(typeof(ColumnAttr), false).First();
    		
    		       string colValue = attr.Name;
                   string nameOfPropertyThatChanges = prop.Name;
                   string objectAValue = prop.GetValue(objectA, null).ToString();
                   string objectBValue = prop.GetValue(objectB, null).ToString();
               }
           }   
        }
    }

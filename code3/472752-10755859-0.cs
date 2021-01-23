    public static class ExtensionMethods
    {
         public static void SetDetailSize(this List<City.Detail> details, int size)
         {
              for (int i = 0; i < size - details.Count; i++) 
                 details.Add(new City.Detail());    
         }
    }

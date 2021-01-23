    public class TheClassYouOperate
    {
        private YourDBContext yourDBContext = new YourDBContext();
    
        public int SaveAndReturnID(YourObject newObject)
        {
            if (ModelState.IsValid) // or CONDITION == TRUE for your case
            {
                yourDBContext.YourObjects.Add(newObject);
                yourDBContext.SaveChanges();
                return newObject.ID;
            }
            return 0; // or null or -1, whatever the way you'll understand insertion fails
        }
    }

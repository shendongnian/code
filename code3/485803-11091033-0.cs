    static class Utilities
    {
        public static void SaveChanges( this MyEntity entity, Student record ) 
        {
             record.Value = SomeNewValue;
             entity.SaveChanges;
        }
    }

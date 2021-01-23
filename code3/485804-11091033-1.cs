    static class Utilities
    {
        public static void SaveChanges( this MyEntity entity, Student record, Student SomeNewValue ) 
        {
             record.Value = SomeNewValue;
             entity.SaveChanges;
        }
    }

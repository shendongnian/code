    public class MyDatabaseClass<T> where T : DbCommand
    {
    
        public virtual T GenerateCommand()
        {
            //.....
        }
    }

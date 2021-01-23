    class MyForm : Form
    {
        public void SomeMethod()
        {
            var dataAccess = new Repository();
            dataAccess.ExecuteQuery();
            if (dataAccess.Exceptions.Any())
            {
                // display your error messages
                form.label1.Text = dataAccess.Exceptions.Select(x => x.ToString());
            }
        }
    }
    class Repository
    {
        private readonly HashSet<Exception> _exceptions = new HashSet<Exception>();
        public IEnumerable<Exception> Exceptions
        {
            get { return _exceptions; }
        }
        public int ExecuteQuery()
        {
            var numberOfRecordsAffected = 0;
            try
            {
                // do something
            }
            catch (Exception ex)
            {
                // normall catching exceptions is a bad idea
                // and you should really catch the exception at the 
                // layer best equiped to deal with it
                _exceptions.Add(ex);
            }
            // but, for the purpose of this example we might want to add some logic to try the query on another database ????
            try
            {
                // do something
            }
            catch (Exception ex)
            {
                _exceptions.Add(ex);
            }
            return numberOfRecordsAffected;
        }
    }

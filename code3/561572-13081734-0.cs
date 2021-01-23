    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            ....
            var filtered = from entity in dt.AsEnumerable()
                           .Where(entity => entity.Field<int>("SerialNumber") == key)
                           select entity;
            ....
        }
        ....
    }

        private Func<Owned<Importer>> importerFactory = //Constructor Injected.
        public string SubmitData(
            User user, Request request)
        {
            History history = m_history.CreateRequest(user);
            //New task which will do an import of data into the DB.
            Task.Factory.StartNew(() =>
                {
                    using (var importer = importerFactory())
                    {
                        importer.Value.Import(user, request, history);
                    }
                });
            /*Return some sort of response back to user so they're not waiting for 
           *the long process to complete           
           */
            return "Response";
        }
        public class Importer
        {
            //m_history ...
            public void Import(
                User user,
                Request request,
                History history)
            {
                var response = Import(user, request, history);
                m_history.Save(history, response);
            }
        }

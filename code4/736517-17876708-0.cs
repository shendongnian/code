        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // don't want to count postbacks
            {
                Document nodeCount = new Document(Node.GetCurrent().Id);
                int Count = 0;
                try
                {
                    Count = Convert.ToInt32(nodeCount.getProperty("hitCount").Value);
                }
                catch
                {
                    Count = 0; // value == null, not set yet
                }
                nodeCount.getProperty("hitCount").Value = Count + 1;
                nodeCount.Save();
                nodeCount.Publish(new User(0));
                umbraco.library.UpdateDocumentCache(nodeCount.Id);
            }

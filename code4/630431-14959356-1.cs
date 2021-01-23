    _container.AddFacility("solr", 
        new SolrNetFacility("http://localhost:8983/solr"));
    var solr = _container.Resolve<ISolrOperations<IndexItem>>();
    solr.Delete(SolrQuery.All);
    
    var docs = from o in Documents
               where o.Attaches.Count > 0
               select o;
    
    foreach (var doc in docs)
    {
    	foreach (var att in doc.Attaches)
    	{
    		try
    		{
    			var file = Directory.GetFiles("C:\\Attachments\\" + doc.Id );
    			foreach (var s in file)
    			{
                           var indexItem = new IndexItem();
                           indexItem.Id = s.FileName;
                           indexItem.Content = File.ReadAllText(s);
    	                   solr.Add(indexItem);    
    			}
    			
    		}
    		catch (Exception)
    		{			
    			throw;
    		}
    	}
    }
    solr.Commit();
    solr.BuildSpellCheckDictionary();

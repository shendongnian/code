             // List view control  
            ListView list = (ListView)FindViewById(Resource.Id.mylist);
            IList<IDictionary<string, object>> mylist = new List<IDictionary<string, object>>();
            IDictionary<string, object> map = new Dictionary<string, object>();
            map.Add("Profit Centre", "Systems");       
            map.Add("Last Updated", "16/02/2012 15:34");       
            mylist.Add(map);       
            map = new Dictionary<string, object>()>;      
            map.Add("Profit Centre", "IDTS");       
            map.Add("Last Updated", "20/02/2012 10:26");       
            mylist.Add(map);       
       
            SimpleAdapter mSchedule = new SimpleAdapter(this, mylist, Resource.Layout.list_item,new String[] {"Profit Centre", "Lasted Updated",}, new int[] { Resource.Id.columnA,  Resource.Id.columnB});       
 
            ListAdapter = mSchedule;

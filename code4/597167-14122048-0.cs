    using Autodesk.AutoCAD.ApplicationServices;
    using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;
    public static void GetObjects()
    {
        List<KeyValuePair<string, ObjectId>> ObjectIds = new List<KeyValuePair<string, ObjectId>>();
        List<string> Filter = new List<string>() { "acppasset", "acppdynamicasset" };
        foreach (Document Document in this.Documents)
        {
            ObjectIdCollection Ids = this.Iterate(Document, Filter);
            if (null != Ids) foreach (var Id in Ids.OfType<ObjectId>()) ObjectIds.Add(new KeyValuePair<string, ObjectId>(System.IO.Path.GetFileNameWithoutExtension(Document.Name), Id));
        }
        this.Results = new Dictionary<string, List<List<KeyValuePair<string, string>>>>();
        foreach (var Id in ObjectIds)
        {
            try
            {
                var Properties = this.GetObject(Id.Value);
                if (null == Properties) continue;
                var Base = Properties.Where(x => x.Key == "Base").FirstOrDefault();
                if (string.IsNullOrWhiteSpace(Base.Value)) continue;
                if (!this.Results.ContainsKey(Base.Value)) this.Results.Add(Base.Value, new List<List<KeyValuePair<string, string>>>());
                this.Results[Base.Value].Add(Properties);
            }   catch { }
        }
    }
     public ObservableCollection<Document> Documents { get; set; }
    
     public ObjectIdCollection Iterate(Document Document, List<string> Filter = null)
            {
                ads_name Instance = new ads_name();
                Database Database = Document.Database;
    
                ObjectIdCollection ValidIds = new ObjectIdCollection();
    
                // Get the last handle in the Database
                Handle Handseed = Database.Handseed;
    
                // Copy the handseed total into an efficient raw datatype
                long HandseedTotal = Handseed.Value;
    
                for (long i = 1; i < HandseedTotal; ++i)
                {
                    string Handle = Convert.ToString(i, 16);
    
                    int Result = acdbHandEnt(Handle, ref Instance);
                    if (Result != 5100) continue; // RTNORM
    
                    ObjectId Id = new ObjectId(Instance.a);
    
                    if (!Id.IsValid) continue;
    
                    try
                    {
                        if (null != Filter)
                        {
                            if (!Filter.Contains(Id.ObjectClass.Name.ToLower())) continue;
                        }
                        
                        using (DBObject DBObject = Id.Open(OpenMode.ForRead, false))
                        {
                            ValidIds.Add(Id);
                            DBObject.Dispose();
                        }
                    }   catch { }
                }
    
                return ValidIds;
        }
        public List<KeyValuePair<string, string>> GetObject(ObjectId Id)
        {
            if (Command.DataLinks != null) try { return Command.DataLinks.GetAllProperties(Id, true); } catch { return null; }
            return null;
        }
    
    public static DataLinksManager DataLinks
    {
        get
        {
            if (null == _DataLinks)
            {
                StringCollection Coll = Autodesk.ProcessPower.DataLinks.DataLinksManager.GetLinkManagerNames();
    
                if (Coll.Count > 0)
                {
                    if (Coll[0] != string.Empty)
                    {
                        _DataLinks = Autodesk.ProcessPower.DataLinks.DataLinksManager.GetManager(Coll[0]);
                    }
                }
            }
    
                return _DataLinks;
            }
        }
        
    private static DataLinksManager _DataLinks;
    public Dictionary<string, List<List<KeyValuePair<string, string>>>> Results { get; set; }

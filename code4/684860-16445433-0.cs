    private List<MyStorageObject> _MyList = null;
    private List<MyStorageObject> MyList
         {
                get {
                    if (this._MyList == null)
                    {
                        this._MyList = (List<MyStorageObject>)Session["MySessionString"];
                    }
                    return this._MyList;
                    }
                set {
                    this._MyList = value;
                    Session["MySessionString"] = value; 
                    }
         }

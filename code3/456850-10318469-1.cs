    protected void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostBack)
       {
           var dataAccess = new PhotoAccess();
           var items = dataAccess.GetPhotos();
    
           lvSubAlbumDB.DataSource = items;
           lvSubAlbumDB.DataBind();
       }
    }
    protected void btSave_OnClick(object sender, EventArgs e)
    {
        var dataAccess = new PhotoAccess();
        dataAccess.UpdateSave(...pass here the parameters or an object which is going to be inserted);
        
        var items = dataAccess.GetPhotos();
    
        lvSubAlbumDB.DataSource = items;
        lvSubAlbumDB.DataBind();
    }

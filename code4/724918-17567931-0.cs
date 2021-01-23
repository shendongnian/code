    private string _AlbumArt;
    public string AlbumArt
    {
       get
       {
         return _AlbumArt;
       }
       set
       {
    if(_AlbumArt!=null)
        _AlbumArt=@"/AlbumArt/"+ value;
    
       }
    }

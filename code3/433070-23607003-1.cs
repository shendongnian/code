    var clmTitle = new OLVColumn();
    
    clmTitle.AspectGetter = obj => (obj as Song).Title;
    
    
    var clmArtist = new OLVColumn();
    
    clmArtist.AspectGetter = obj => (obj as Song).Artist;
    
    objectListView1.Columns.AddRange(new OlVColumn[]{clmTitle,clmArtist});
    
    objectListView1.SetObjects(songs);

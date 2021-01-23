    public int GetPreviousPictureId(int id)
    {
    	var picture = db.Pictures.Where(x => x.Id < id).OrderByDescending(x => x.Id).FirstOrDefault();
    
    	if (picture != null)
    		return picture.Id;
    
    	return 0;
    }
    
    public int GetNextPictureId(int id)
    {
    	var picture = db.Pictures.Where(x => x.Id > id).OrderBy(x => x.Id).FirstOrDefault();
    
    	if (picture != null)
    		return picture.Id;
    
    	return 0;
    }

    public SessionImages Add(Sessions SessionModel, SessionImages ImageModel)
    {
        try
        {
            SessionModel.Images.Add(ImageModel);
            SessionModel.PhotosCount = SessionModel.Images.Count;
            context.Entry(SessionModel).State = System.Data.EntityState.Modified;                
            context.SaveChanges();
        }
        catch
        {
            return null;
        }
        return ImageModel;
    }

    public void DeletePicture(long documentImageID)
            {
                if (documentImageID != null)
                {
                    if(Session["imagesIdForDeleting"]) == null
                    {
                          Session["imagesIdForDeleting"] = new List<long>();
                     }
                    ((List<long>)Session["imagesIdForDeleting"]).Add( documentImageID);
                }
            }

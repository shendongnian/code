        public void DeletePicture(long documentImageID)
        {
            if(Session["imagesIdForDeleting"] == null)
            {
               Session["imagesIdForDeleting"] = new List<long>();
            }
            if (documentImageID != null)
            {
                var list = (List<long >)Session["imagesIdForDeleting"];
                list.Add(documentImageID);
            }
        }

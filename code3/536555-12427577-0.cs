    internal static bool HasLocalAccount(int userId)
            {
                using (YOUREntities db = new YOUREntities ()) 
                {
                    webpages_Membership wm = db.webpages_Membership.Where(x => x.UserId == userId).FirstOrDefault();
    
                    if (wm != null) return true;
                    return false;
                }
    
            }

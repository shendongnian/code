     [HttpPost, ActionName("Delete")]
     public ActionResult DeleteConfirmed(int id) 
     {
         var currentUser = db.UserProfiles.Where(u => u.UserName.Equals(User.Identity.Name)).Single();
         Post post = db.Posts.Find(id);      
         if (post.UserId==currentUser.UserId)
         {
            {
              db.Posts.Remove(post);
              db.SaveChanges();
              return RedirectToAction("Index");
            }  
         }    
      }
      
                       

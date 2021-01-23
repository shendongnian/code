    [HttpPost, ActionName("Delete")]
    [RequiredPermissions(RequiredPermissionName, Operation.Delete)]
    public ActionResult DeleteConfirmed(int userIdWhoGone)
    {
        _db.Users.RemoveById(userIdWhoGone); // You may need to create this.
        // Atlernatively, get the user by id then call 'Remove()
        var user = _db.User.Find(userIdWhoGone);
        _db.Users.Remove(user);
 
        _db.SaveChanges();
        this.TempData["msg"] = "Deleted User Id " + userIdWhoGone;
        return RedirectToAction("Index");
    }

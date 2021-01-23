        //
        // POST: /Divisions/Delete/5
        [HttpPost, ActionName("Delete"), Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Division division = _db.Divisions.Single(x => x.DivisionId == id);
            string errorMessage;
            if (DbRelationEnforcer.CanDelete(_db, division, out errorMessage))
            {
                division.SetDeleted(User.Identity.Name);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", new {Id = id});
        }

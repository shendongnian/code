        [HttpPost]
        public JsonResult DeleteCotnact(int id)
        {
            using (MycasedbEntities dbde = new MycasedbEntities())
            {
                Contact rowcontact = (from c in dbde.Contact
                                         where c.Id == id
                                         select c).FirstOrDefault();
                dbde.Contact.Remove(rowcontact);
                dbde.SaveChanges();
                return Json(id);
            }
        }

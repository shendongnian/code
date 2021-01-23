        [OutputCache(Duration = 0)]
        public JsonResult Delete(string roleName)
        {
            bool isError = false;
            bool isDeleted = Roles.Provider.DeleteRole(roleName, true);
            if (!isDeleted)
            {
                isError = true;
            }
            return Json(new { IsDeleted = isDeleted, IsError = isError }, JsonRequestBehavior.AllowGet);
        }

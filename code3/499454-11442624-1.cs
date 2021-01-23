        [HttpPost]
        public JsonResult ValidateForEdit(int id)
        {
            var cliente = db.Clients.Find(id);
            return cliente != null ? Json(true) : Json(false);
        }

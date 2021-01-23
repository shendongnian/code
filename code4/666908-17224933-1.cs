     public ActionResult GetClientList()
     {
         List<ClientModel> clientList = ClientRepository.GetClients();
         return Json(new JsonMixedResult { Result = "success", ViewHtml = this.RenderPartialView("ClientList", clientList) }, JsonRequestBehavior.AllowGet);
     }

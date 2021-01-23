    public ActionResult searchUser(int id)
    {
      UserEntity user=repo.GetUserFromID(id);
      return Json(new { UserName=user.UserName, ID=id},
                                                    JsonRequestBehaviour.AllowGet);
    }

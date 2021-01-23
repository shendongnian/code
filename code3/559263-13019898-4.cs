    public class DeleteUserModel
    {
        public DeleteUser User { get; set; }
        public class DeleteUser
        {
            public string Username { get; set; }
        }
    }
    [HttpPost]
    public ActionResult Delete(DeleteUserModel model)
    {
        Membership.DeleteUser(model.User.UserName);
    }

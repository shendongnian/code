    public class RolesController : Controller
    {
        ...
        public ActionResult ChooseRolePartial(string username)
        {
            var userRoles = Roles.GetRolesForUser(username);
            var roles = Roles.GetAllRoles().Select(x => new SelectListItem
            {
                Value = x,
                Text = x,
                Selected = userRoles.Contains(x)
            }).ToArray();
            var model = new ChooseRoleModel
            {
                Roles = roles,
                Username = username
            };
            return PartialView("Partials/ChooseRolePartial", model);
        }
        [HttpPost]
        public ActionResult ChooseRolePartial(ChooseRoleModel model)
        {
            ...
        }
    }

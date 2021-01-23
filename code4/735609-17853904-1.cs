        [Authorize]
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Default(List<string> HelpIds)
        {
            List<UserAssistanceViewModel> models = new List<UserAssistanceViewModel>();
            foreach (string helpId in HelpIds)
            {
                UserAssistanceViewModel model = new UserAssistanceViewModel();
                model.Content = (Resources.UserAssistance.Content.GetResourceById(helpId));
                model.Title = (Resources.UserAssistance.Titles.GetResourceById(helpId));
                model.Id = helpId;
                models.Add(model);
            }
            return Json(models, JsonRequestBehavior.AllowGet);
        }

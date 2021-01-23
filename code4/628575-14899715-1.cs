                string link;
                if (!string.IsNullOrEmpty(routeName))
                {
                    link = helper.RouteLink(text, routeName, newValues).ToString();
                }
                else
                {
                    actionName = actionName ?? values["action"].ToString();
                    controllerName = controllerName ?? values["controller"].ToString();
                    link = helper.ActionLink(text, actionName, controllerName, newValues, null).ToString();
                }
                return string.Concat(" ", link);

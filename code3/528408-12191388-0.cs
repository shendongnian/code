    if (Request["__EVENTTARGET"] != null)
            {
                string controlID = Request["__EVENTTARGET"];
                if (controlID.Equals(analysisGroup.ID))
                {
                    string selectedValue =  Request.Form[Request["__EVENTTARGET"]].ToString();
                    Session["SelectedValue"] = selectedValue; //Keep it in session if other controls are also doing post backs.
                }
            }

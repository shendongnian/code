            protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                  if (e.CommandName.ToUpper().ToString() == "DELETE")
                  {
                     ViewState["id"] = e.CommandArgument.ToString().Trim();
                     Model.question del = new Model.question();
                    del.ActivityID = Convert.ToInt32(gvQuesViewState["id"]).ToString());             
                    del.TaskID = Convert.ToInt32(ViewState["id"]).ToString());             
                    daoQuestion.Delete(del);
                  }
                 daoQuestion.Save(); 
            }

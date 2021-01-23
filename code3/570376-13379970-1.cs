    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            string parameter= e.CommandArgument.ToString();
            if (currentCommand.Equals("Ignorar"))
            {
                yourMethodName(parameter);
            }
        }

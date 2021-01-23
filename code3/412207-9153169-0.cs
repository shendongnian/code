    public void DynamicClick(object sender, EventArgs e)
        {
            var editLink = ((LinkButton)sender);
            string info = editLink.CommandArgument;
            string[] arg = new string[2];
            char[] splitter = { ',' };
            arg = info.Split(splitter);
            var var1 = arg[0];
            var var2 = arg[1];
            var var3 = arg[2];
        }

       protected void gvChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var raiseSelectedIndexChanged = RaiseSelectedIndexChanged ;
            if(raiseSelectedIndexChanged!=null)
            {
                raiseSelectedIndexChanged(sender, e);
            }
        }

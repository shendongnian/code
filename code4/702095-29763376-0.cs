        protected void MyRepeater_OnItemCreated(object sender, RepeaterItemEventArgs e)
        {
            //Inside ItemCreatedEvent
            ScriptManager scriptMan = ScriptManager.GetCurrent(this);
            LinkButton btn = e.Item.FindControl("btnSubmit") as LinkButton;
            if (btn != null)
            {
                btn.Click += btnSubmit_Click;
                scriptMan.RegisterAsyncPostBackControl(btn);
            }
        }

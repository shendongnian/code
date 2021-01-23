        protected override void OnInit(EventArgs e)
        {
            CurrentScriptManager = BuildScriptManager();
            base.OnInit(e);
        }
        private ScriptManager BuildScriptManager()
        {
            ScriptManager rtn;
            var script = Items[typeof (ScriptManager)];
            if (script == null)
            {
                rtn = new ScriptManager
                          {
                              EnablePartialRendering = false
                          };
                Form.Controls.AddAt(0, rtn);
            }
            else
            {
                rtn = (ScriptManager) script;
            }
            rtn.EnablePageMethods = false;
            rtn.AjaxFrameworkMode = AjaxFrameworkMode.Disabled;
            rtn.EnableCdn = true;
            return rtn;
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(null)]
        public string TemporaryDirectory
        {
            get
            {
                if (this["TemporaryDirectory"] == null)
                {
                    return System.IO.Path.GetTempPath();
                }
                return ((string)this["TemporaryDirectory"]);
            }
            set
            {
                if (System.IO.Directory.Exists(value) == false)
                {
                    throw new System.IO.DirectoryNotFoundException("Directory does not exist.");
                }
                this["TemporaryDirectory"] = value;
            }
        }

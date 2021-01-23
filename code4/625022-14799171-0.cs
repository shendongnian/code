        //Application settings wrapper class 
        sealed class FormSettings : ApplicationSettingsBase
        {
            [UserScopedSettingAttribute()]
            public string FilePath
            {
                get { return (string )(this["FilePath"]); }
                set { this["FilePath"] = value; }
            }
        }

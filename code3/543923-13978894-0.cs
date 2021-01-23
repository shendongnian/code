         If My.Settings.Properties(settingName) Is Nothing Then
            Dim p = New Configuration.SettingsProperty(settingName)
            p.Provider = My.Settings.Providers("LocalFileSettingsProvider")
            p.Attributes.Add(GetType(Configuration.UserScopedSettingAttribute), _
                                        New Configuration.UserScopedSettingAttribute())
            p.PropertyType = GetType(SampleEnum)
            My.Settings.Properties.Add(p)
            If My.Settings(settingName) Is Nothing Then
               My.Settings(settingName) = SampleEnum.DefaultValue
            End If
         End If

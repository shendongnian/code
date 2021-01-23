    private static InputLanguage GetInutLanguageByName(string layOut)
        {
            foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
            {
                if (lng.Culture.DisplayName == layOut)
                {
                    return lng;
                }
            }
            return null;
        }
    private void SetKeyboardLayout(InputLanguage Layout)
        {
            InputLanguage.CurrentInputLanguage = Layout;
        }
    private void FirstNameTextBox_Enter(object sender, EventArgs e)
        {
		
            SetKeyboardLayout(GetInutLanguageByName("Persian"));
        }

     InputLanguage arabic;
            InputLanguage english;
            private void Form1_Load(object sender, EventArgs e)
            {
                arabic = InputLanguage.CurrentInputLanguage;
                english = InputLanguage.CurrentInputLanguage;
                int count = InputLanguage.InstalledInputLanguages.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("Arabic"))
                    {
                        arabic = InputLanguage.InstalledInputLanguages[i];
                    }
                    if (InputLanguage.InstalledInputLanguages[i].LayoutName.Contains("English"))
                    {
                        english = InputLanguage.InstalledInputLanguages[i];
                    }
                }
            }
            private void txtArabic_Enter(object sender, EventArgs e)
            {
                InputLanguage.CurrentInputLanguage = arabic;
            }
    
            private void txtEnglish_Enter(object sender, EventArgs e)
            {
                InputLanguage.CurrentInputLanguage = english;
            }

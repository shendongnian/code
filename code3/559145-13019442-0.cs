    var StoredPlaceholders = (CustomConfigurationSection)ConfigurationManager.GetSection("MailPlaceholders");
     foreach (CustomConfigurationSection placeholder in StoredPlaceholders.SubSections["placeholder"])
                {
                    MailReplacements.Add(new MailPlaceholder
                    {
                        Placeholder = placeholder.Attributes["name"],
                        Formcontrol = placeholder.Attributes["form"]
                    });
                }
                foreach (MailPlaceholder replacement in MailReplacements)
                {
                    if ( !String.IsNullOrEmpty(replacement.Formcontrol))
                    {
                        TextBox txt = RequestForm.FindControl(replacement.Formcontrol) as TextBox;
                        if (txt != null) replacement.ReplacementValue = txt.Text;
                    }
                }

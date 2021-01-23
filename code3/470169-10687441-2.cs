       string common = " (Table.Name in (";
                for (int i = 0; i < settings.SelectedCommonLabs.Count; i++)
                {
                    common += string.Format("'{0}'", settings.SelectedCommonLabs[i]);
                    if (i < settings.SelectedCommonLabs.Count - 1)
                        common += ", ";
                }
                common += ")) ";
                conditionStrings.Add(common);

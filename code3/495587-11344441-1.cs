    public void Translate(Action<string> assignToTarget, string SectionKeyName)
            {
                assignToTarget(SectionKeyName);
                if (!string.IsNullOrEmpty(SectionKeyName))
                {
                    string translation = Translator.Translate(SectionKeyName);
                    if (!string.IsNullOrEmpty(translation))
                    {
                        assignToTarget(translation);
                    }
                }
            }

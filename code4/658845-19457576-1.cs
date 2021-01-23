    public list<string> validate(string[] tokens)
    {
          Hunspell hunspell = new Hunspell("en_US.aff", "en_US.dic");
          List<string> valid_tokens = new List<string>();
          foreach (string token in tokens)
          {
               if (!hunspell.Spell(token))
               {
                    valid_tokens.Add(token);
               }
          }
          hunspell.Dispose();
          return valid_tokens;
    }

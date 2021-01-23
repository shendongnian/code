     bool _Error = false;
     ThesResult _tr = null;
     try { _tr = engine["en"].LookupSynonyms(_Word, true); }
     catch (Exception)
           {
              _Error = true;
           }
           if (_Error)
           {
               _Synonyms.Add(word);
           }
           else
             {
                        List<string> SynonymNew = new List<string>();
                        foreach (ThesMeaning meaning in _tr.Meanings)

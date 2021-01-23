        Word[] catWords = null;
        if (lex != null)
        {
            IEnumerable<XElement> words = lex.Elements("word");
            catWords = (from itm in words
                        where itm.Element("category") != null
                            && itm.Element("category").Value == "verb"
                            && itm.Element("id") != null
                            && itm.Element("base") != null
                        select new Word() 
                        {
                            Base = itm.Element("base").Value,
                            Category = itm.Element("category").Value,
                            Id = itm.Element("id").Value,
                        }).ToArray<Word>();
        }

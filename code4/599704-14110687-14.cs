    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    
    namespace test
    {
        class Program
        {
    
            class Word
            {
                public string Base { get; set; }
                public string Category { get; set; }
                public string Id { get; set; }
            }
                    
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Parse(INPUT_DATA);
                XElement lex = doc.Element("lexicon");
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
    
                //print it
                if (catWords != null)
                {
                    Console.WriteLine("Words with <category> and value verb:\n");
                    foreach (Word itm in catWords)
                        Console.WriteLine("[Found]\n Id: {0}\n Base: {1}\n Category: {2}\n", 
                            itm.Id, itm.Base, itm.Category);
                }
            }
    
            const string INPUT_DATA =
            @"<?xml version=""1.0""?>
            <lexicon>
            <word>
              <base>a</base>
              <category>determiner</category>
              <id>E0006419</id>
            </word>
            <word>
              <base>abandon</base>
              <category>verb</category>
              <id>E0006429</id>
              <ditransitive/>
              <transitive/>
            </word>
            <word>
              <base>abbey</base>
              <category>noun</category>
              <id>E0203496</id>
            </word>
            <word>
              <base>ability</base>
              <category>noun</category>
              <id>E0006490</id>
            </word>
            <word>
              <base>able</base>
              <category>adjective</category>
              <id>E0006510</id>
              <predicative/>
              <qualitative/>
            </word>
            <word>
              <base>abnormal</base>
              <category>adjective</category>
              <id>E0006517</id>
              <predicative/>
              <qualitative/>
            </word>
            <word>
              <base>abolish</base>
              <category>verb</category>
              <id>E0006524</id>
              <transitive/>
            </word>
            </lexicon>";
    
        }
    }

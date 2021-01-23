    int repeat;
            if (Value.Count() > 254)
                repeat = ((Value.Count() / 255));
            //string spiltedText;
            else
                repeat = 0;
            if (repeat > 0)
            {
                for (int i = 0; i <= repeat; i++)
                {
                    try { spiltedText = Value.Substring(i * 248, 248); spiltedText += "<الوصف>"; }
                    catch { spiltedText = Value.Substring(i * 248, Value.Count() - (i * 248) - 1); }
                    range.Find.Execute(findtext, findmatchcase, findmatchwholeword,
                        findmatchwildcards, findmatchsoundslike, findmatchallwordforms, findforward,
                        findwrap, findformat, spiltedText, findreplace, missing,
                        missing, missing, missing);
                }
            }
            else
            range.Find.Execute(findtext, findmatchcase, findmatchwholeword,
                    findmatchwildcards, findmatchsoundslike, findmatchallwordforms, findforward,
                    findwrap, findformat, spiltedText, findreplace, missing,
                    missing, missing, missing);
        }

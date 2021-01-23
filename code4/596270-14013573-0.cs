            int ndx;
            while ((ndx = callNotes.GetNextSpellingErrorCharacterIndex(0, LogicalDirection.Forward)) != -1) 
            {
                var err = callNotes.GetSpellingError(ndx);
                foreach (String sugg in err.Suggestions)
                {
                    err.Correct(sugg);
                    break;
                }
            }

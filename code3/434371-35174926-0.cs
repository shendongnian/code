    private static void InsertIntoBookmark(BookmarkStart bookmarkStart, string text)
            {
                OpenXmlElement elem = bookmarkStart.NextSibling();
                bool firstRunReplaced = false;
                while (elem != null && !(elem is BookmarkEnd))
                {
                    OpenXmlElement nextElem = elem.NextSibling();
                    if (elem is Run && !firstRunReplaced)
                    {
                        ((Run)elem).Elements<Text>().First().Text = text;
                        firstRunReplaced = true;
                    }
                    else
                    {
                        elem.Remove();
                    }
                    elem = nextElem;
                }
            }

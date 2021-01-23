       string page = "<Special!>The moon is crashing to the Earth!</Special!>";
            if (page.Contains("</Special!>"))
            {
                pos = page.IndexOf("<Special!>");
                propertyAddress = page.Substring(10, page.IndexOf("</Special!>")-11);
                //i used 10 because <special!> is 10 chars, i used 11 because </special!> is 11
            }

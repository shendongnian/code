     String s = "";
                foreach (String item in Request.QueryString.Keys)
                {
                    s = Request.QueryString[item];
                }
                if (s != "")
                {
                    id = Int32.Parse(s);
                }

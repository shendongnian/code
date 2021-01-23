        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<State> GetStatesWithAbbr(string id)
        {
            List<State> sbStates = new List<State>();
            XmlDocument doc = new XmlDocument();
            string filePath = HttpContext.Current.Server.MapPath("~/App_Data/States.xml");
            doc.Load(filePath);
            try
            {
                foreach (XmlElement xnl in doc.DocumentElement.ChildNodes)
                {
                    State st = new State();
                    st.Name = xnl.Attributes["name"].Value;
                    st.Abbreviation = xnl.Attributes["abbreviation"].Value;
                    st.value = xnl.Attributes["name"].Value;
                    sbStates.Add(st);
                }
            }
            catch (Exception ex)
            {
                string exp = ex.ToString(); //Setup a breakpoint here to verify any exceptions raised.
            }
            return sbStates;
        }

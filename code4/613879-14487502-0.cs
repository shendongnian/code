    XDocument xdoc = XDocument.Load(this.Server.MapPath("~/config/ideas.xml"));
    
    List<Ideas> cat = from p in xdoc.Descendants("countries").Elements("country")
                             .Select(m => new Ideas 
                                 {
                                     Country = m.Attribute("ID").Value, 
                                     ListIdeas = m.Elements("idea")
                                     .Select(c => 
                                         new ListItem 
                                         {
                                             Text = c.Attribute("ID").Value , 
                                             Value = c.Value
                                         }).ToList()
                                 }) select p;

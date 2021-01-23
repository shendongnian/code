    var resultSetTicketNo   =   from a in dtbl1.AsEnumerable()
                            join b in dtbl2.AsEnumerable()
                            on a.Field<int>("ID") equals b.Field<int>("LinkID")
                            group a by new
                            {
                                Age = a["Age"],
                                ID = a["ID"],
                                Name = a["Name"]
                            } into g
                            select new
                            {
                                g.Key.Name,
                                g.Key.Age,
                                g.Key.ID,
                                Counter=g.Count()
                            };
        foreach (var a in resultSetTicketNo)
        {
            Response.Write(a.ID + "~" + a.Name + "~" + a.Age + "~" + a.Counter + "<br/>");
        }
        Response.Write("<br/><br/>end of resultSetTicketNo<br/><br/>");

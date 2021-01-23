     if (IsPostBack)
            {
    
                string dllArea = AreaDropDown.SelectedValue;
                int dllAreaNum;
    
                int.TryParse(dllArea, out dllAreaNum);
    
                using (TicketContext adrop = new TicketContext())
                {
                    var result = (from a in adrop.Tickets
                                  where (a.AreaID == dllAreaNum)
                                  select new { a.TicketSubArea, a.Description, a.TicketID }).ToList();
    
                    ticketList.DataSource = result;
                    ticketList.DataBind();
    
                }

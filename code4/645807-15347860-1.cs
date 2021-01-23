                    if (IsPostBack)
                    {
            
                        string dllArea = AreaDropDown.SelectedValue;
                        int dllAreaNum;
            
                        int.TryParse(dllArea, out dllAreaNum);
                       
                           IQueryable<Ticket> result = getTicketbyArea(dllAreaNum)
            
            
                            ticketList.DataSource = result;
                            ticketList.DataBind();
            }
       }

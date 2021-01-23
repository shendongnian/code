    public List<SelectListItem> GetCustomerDD()
    {
        List<SelectListItem> dropDown;
        try
        {
            OpenConnection();
            // .ToList() here makes sure you get the result immidiately
            dropDown = _context.Customers.Select(m => new SelectListItem { Text = m.Description, Value = m.CustomerID.ToString() })
                .ToList();              
        }
        finally
        {   
            // try-finally makes sure you always close your connection
            CloseConnection();
        }
        return dropDown;
    }

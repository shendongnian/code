    // get all data
    Publishers = db.Publishers.ToList();
    
    // filter by site url 
    if(!String.IsNullOrEmpty(txtFilterBy_SiteURL.Text))
    {
        Publishers = Publishers.Where(p => String.IsNullOrEmpty(p.SiteURL) &&
                     p.SiteURL.ToLower().Contains(txtFilterBy_SiteURL.Text)
                     ).ToList();
    }
    // filter by keyword 
    if(!String.IsNullOrEmpty(txtFilterBy_KeyWord.Text))
    {
        Publishers = Publishers.Where(p => String.IsNullOrEmpty(p.Keywords) &&
                     p.Keywords.ToLower().Contains(txtFilterBy_KeyWord.Text)
                     ).ToList();
    }

    var query = from product in db.Products select product;
    if(price.Checked && ascending.Checked)
    {
        query = query.OrderBy(product => product.Price);
    }
    else if(price.Checked && !ascending.Checked)
    {
        query = query.OrderByDescending(product => product.Price);
    }
    else if(!price.Checked && ascending.Checked)
    {
        query = query.OrderBy(product => product.Name);
    }
    else
    {
        query = query.OrderByDescending(product => product.Name);
    }

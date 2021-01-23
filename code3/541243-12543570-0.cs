    //don't save the image yet, or save it in a temporary location
    db.Products.AddObject( product );
    db.SaveChanges();
    product.ImagePath = //path including product.Id
    //save or move image to product.ImagePath
    db.SaveChanges();

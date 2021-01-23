    Dynamic tempResult = null;
    
    foreach(var keyword in keywordArray)
    {
    
        if (tempResult == null) {
            tempResult = products.Where(p => p.ProductDesc.Contains(keyword));
        }
        else {
    
            tempResult = tempresult.Union(products.Where(p => p.ProductDesc.Contains(keyword)));
        }
    }

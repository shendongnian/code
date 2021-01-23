    foreach (HttpPostedFile hpf in hfc)
    {
        if(hpf.ContentLength > 11000000)
        {
            blnBytes = false;
            break;
        }
        intBytes += hpf.ContentLength;
        if (intBytes > 11000000)
        {
            blnBytes = false;
            break;
        }
    }

    var db = new MvcCMS.Models.MvcCMSContext();
    if (values[parameterName] != null)
    {
        var permalink = values[parameterName].ToString();
        var page =  db.CMSPages.Where(p => p.Permalink == permalink).FirstOrDefault();
        if(page != null)
        {
            HttpContext.Items["cmspage"] = page;
            return true;
        }
        return false;
    }
    return false;

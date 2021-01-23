    using System.Web.Mvc; // Wrong namespace for HttpGet attribute !!!!!!!!!
    [HttpGet]
    public string Blah()
    {
        return "blah";
    }

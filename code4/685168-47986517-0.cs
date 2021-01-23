    public ActionResult Upload()
    {
        var r = Request;
        byte[] ba = r.BinaryRead(r.ContentLength);
       ...
     }

    public IEnumerable<Appointments> GetAll(int id)
    {
        var msg = string.empty;
        IEnumerable<Appointments> appointments= null;
        try {
            icdb.Appointments.Where(m => m.Id== id).AsEnumerable();
        }
        catch {
            msg = "some custom message you want to return";
            return Request.CreateResponse<string>(HttpStatusCode.BadRequest, msg);
        }
        return appointments;
    }

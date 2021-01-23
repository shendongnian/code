    public IEnumerable<Appointments> GetAll(int id)
    {
        IEnumerable<Appointments> appointments= null;
        try {
            icdb.Appointments.Where(m => m.Id== id).AsEnumerable();
        }
        catch {
            var message = new HttpResponseMessage(HttpStatusCode.BadRequest);
            message.Content = new StringContent("some custom message you want to return");
            throw new HttpResponseException(message);
        }
        return appointments;
    }

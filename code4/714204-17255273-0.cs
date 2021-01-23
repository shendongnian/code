    public static Result<Request, string>.Success AsSuccess(this Result<Request, string> res) {
        return (Result<Request, string>.Success)res;
    }
    // And then use it
    var successData = res.AsSuccess().Item;

    [HttpGet]
    [Route("device/search/{property}/{value}")]
    public SearchForDeviceResponse SearchForDevice(string property, string value)
    {
        //todo: limit search property here?
        var response = new SearchForDeviceResponse();
        var results = _deviceManagementBusiness.SearchForDevices(property, value);
        response.Success = true;
        response.Data = results;
        var statusCode = results == null || !results.Any() ? HttpStatusCode.NoContent : HttpStatusCode.OK;
        return SendResponse(response, statusCode);
    }

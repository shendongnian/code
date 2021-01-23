    public async Task<IActionResult> OnGet(string messageId)
    {
        try
        {
            if (!string.IsNullOrEmpty(messageId))
            {
                var ringCentral = _configuration.GetSection("RingCentral");
                var clientId = ringCentral.GetValue<string>("ClientId");
                var clientSecret = ringCentral.GetValue<string>("ClientSecret");
                var userName = ringCentral.GetValue<string>("Username");
                var password = ringCentral.GetValue<string>("Password");
                var ext = ringCentral.GetValue<string>("Extension");
                bool production = ringCentral.GetValue<bool>("Production");
                using (var rc = new RingCentral.RestClient(clientId, clientSecret, production, "FaxSystem"))
                {
                    await rc.Authorize(userName, ext, password);
                    var extension = rc.Restapi().Account().Extension();
                    var content = await extension.MessageStore(messageId).Content(messageId).Get();
                    return new FileContentResult(content, "application/pdf");
                }
            }
            return Page();
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            throw;
        }
    }

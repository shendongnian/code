    public async Task<IActionResult> OnGet(string messageId)
    {
        try
        {
            using (var rc = new RingCentral.RestClient(setting.ClientId, setting.ClientSecret, setting.Production, "Fax"))
            {
                await rc.Authorize(setting.UserName, setting.Extension, setting.Password);
                var extension = rc.Restapi().Account().Extension();
                var outputPDF = await extension.MessageStore(messageId).Content(messageId).Get();
                return new FileContentResult(outputPDF, "application/pdf");
            }
            return Page();
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            throw;
        }
    }

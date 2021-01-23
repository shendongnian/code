    // Read in your template from anywhere (database, file system, etc.)
    var bodyTemplate = GetEmailBodyTemplate();
    // Substitute variables using Razor
    var model = new { Name = "John Doe", OtherVar = "Hello!" };
    var emailBody = Razor.Parse(bodytemplate, model);
    // Send email
    SendEmail(address, emailBody);

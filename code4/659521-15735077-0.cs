    var errors = _errorsRepository.Errors.ToList().
    Select(e => new ErrorViewModel
    {
        ErrorId = e.ErrorId,
        Application = e.Application,
        Host = e.Host,
        Type = e.Type,
        Source = e.Source,
        Message = e.Message,
        User = e.User,
        StatusCode = e.StatusCode,
        TimeUtc = TimeZoneInfo.ConvertTimeFromUtc(
            e.TimeUtc, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")),
        Sequence = e.Sequence,
        AllXml = e.AllXml
     });

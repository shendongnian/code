    // using System.Reflection;
    // using System.Net.Http;
    // private const string SEND_STATUS_FIELD_NAME = "_sendStatus";
    private void ResetSendStatus(HttpRequestMessage request)
    {
        TypeInfo requestType = request.GetType().GetTypeInfo();
        FieldInfo sendStatusField = requestType.GetField(SEND_STATUS_FIELD_NAME, BindingFlags.Instance | BindingFlags.NonPublic);
        if (sendStatusField != null)
            sendStatusField.SetValue(request, 0);
        else
            throw new Exception($"Failed to hack HttpRequestMessage, {SEND_STATUS_FIELD_NAME} doesn't exist.");
    }

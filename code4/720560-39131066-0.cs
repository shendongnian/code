        public T AssignErrorMessage<T>(T response, string errorDescription, int errorCode)
        {
            PropertyInfo ErrorMessagesProperty = response.GetType().GetProperty("ErrorMessage");
            if (ErrorMessagesProperty.GetValue(response, null) == null)
                ErrorMessagesProperty.SetValue(response, new ErrorMessage());
            PropertyInfo ErrorCodeProperty = ErrorMessagesProperty.GetType().GetProperty("code");
            ErrorCodeProperty.SetValue(response, errorCode);
            PropertyInfo ErrorMessageDescription = ErrorMessagesProperty.GetType().GetProperty("description");
            ErrorMessageDescription.SetValue(response, errorDescription);
            return response;
        }
        public class ErrorMessage
        {
            public int code { get; set; }
            public string description { get; set; }
        }

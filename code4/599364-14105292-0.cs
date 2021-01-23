    public Stream TestMultipartMime(Stream data)
    {
        // Re-construct the multipart/form-data content
        MultipartFormData multipartFormData = new MultipartFormData(WebOperationContext.Current.IncomingRequest, data);
        HttpMultipartMimeForm responseForm = new HttpMultipartMimeForm(multipartFormData.Items);
        responseForm.Add("ErrorCode", "Success");
        responseForm.Add("ErrorMessage", "None");
        HttpResponseMessage responseMsg = new HttpResponseMessage();
        responseMsg.StatusCode = System.Net.HttpStatusCode.OK;
        responseMsg.Content = responseForm.CreateHttpContent();
        WebOperationContext.Current.OutgoingResponse.ContentType = "multipart/form-data; boundary=" + multipartFormData.Boundary;
        WebOperationContext.Current.OutgoingResponse.Headers["Accept"] = "multipart/form-data";
        return responseMsg.Content.ReadAsStream();
    }

    var output =  new Result() { Status = Status.Error.ToString(), Data = null, Message = arr };
    actionContext.Response = new HttpResponseMessage {
                    Content = new StringContent(JsonConvert.SerializeObject(output), Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.OK
                };

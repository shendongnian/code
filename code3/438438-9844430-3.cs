    Task<string>[] taskArray = new Task<string>[]
        {
            Task.Factory.StartNew(() => {
                var client = new WebClient();
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var json = client.UploadString("http://localhost:45868/Product/GetAvailableProductsByContact",
                                         jsonser1);
                return json;
            }),
            Task.Factory.StartNew(() => {
                var client = new WebClient();
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var json = client.UploadString("http://localhost:45868/Product/GetMemberProductsByContact",
                                         jsonser2);
                return json;
            }),
            Task.Factory.StartNew(() => {
                var client = new WebClient();
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var json = client.UploadString("http://localhost:45868/Product/GetCoachProductsByContact",
                                         jsonser3);
                return json;
            }),
        };
    // the request for .Result is blocking and waits until each task
    // is completed before continuing; however, they should also all
    // run in parallel instead of sequentially.
    var resultJson1 = taskArray[0].Result;
    var resultJson2 = taskArray[1].Result;
    var resultJson3 = taskArray[2].Result;

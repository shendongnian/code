     using (var postStream = request.EndGetRequestStream(asynchronousResult))
                {
                    string postData = "entry.0.single=testdata";
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    postStream.Write(byteArray, 0, postData.Length);
                }
    
     workCompleted.Set();//work completed,signal BeginGetRequestExample.

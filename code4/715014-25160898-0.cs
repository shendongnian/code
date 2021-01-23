    string wopiOverride = Request.Headers.GetValues("X-WOPI-Override").First();
    if (wopiOverride.Equals("COBALT"))
    {
       string filename = name;
       EditSession editSession = CobaltSessionManager.Instance.GetSession(filename);
       var filePath = HostingEnvironment.MapPath("~/App_Data/");
       if (editSession == null){
          var fileExt = filename.Substring(filename.LastIndexOf('.') + 1);
          if (fileExt.ToLower().Equals(@"xlsx"))
             editSession = new FileSession(filename, filePath + "/" + filename, @"yonggui.yu", @"yuyg", @"yonggui.yu@emacle.com", false);
          else
             editSession = new CobaltSession(filename, filePath + "/" + filename, @"patrick.racicot", @"Patrick Racicot", @"patrick.racicot@hospitalis.com", false);
             CobaltSessionManager.Instance.AddSession(editSession);
          }
    
          //cobalt, for docx and pptx
          var ms = new MemoryStream();
    
          HttpContext.Current.Request.InputStream.CopyTo(ms);
          AtomFromByteArray atomRequest = new AtomFromByteArray(ms.ToArray());
          RequestBatch requestBatch = new RequestBatch();
    
          Object ctx;
          ProtocolVersion protocolVersion;
    
          requestBatch.DeserializeInputFromProtocol(atomRequest, out ctx, out protocolVersion);
          editSession.ExecuteRequestBatch(requestBatch);
    
    
          foreach (Request request in requestBatch.Requests)
          {
             if (request.GetType() == typeof(PutChangesRequest) && request.PartitionId == FilePartitionId.Content)
             {
                 //upload file to hdfs
                 editSession.Save();
             }
          }
          var responseContent = requestBatch.SerializeOutputToProtocol(protocolVersion);
          var host = Request.Headers.GetValues("Host");
          var correlationID = Request.Headers.GetValues("X-WOPI-CorrelationID").First();
    
          response.Headers.Add("X-WOPI-CorrelationID", correlationID);
          response.Headers.Add("request-id", correlationID);
          MemoryStream memoryStream = new MemoryStream();
    
          var streamContent = new PushStreamContent((outputStream, httpContext, transportContent) =>
          {
             responseContent.CopyTo(outputStream);
             outputStream.Close();
          });
    
          response.Content = streamContent;
          response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
          response.Content.Headers.ContentLength = responseContent.Length;
    }

            }
            else if (context.Request.HttpMethod.Equals(@"POST") && context.Request.Headers["X-WOPI-Override"].Equals("COBALT"))
            {
                Console.WriteLine(@"Got a cobalt request for the file");
                var ms = new MemoryStream();
                context.Request.InputStream.CopyTo(ms);
                AtomFromByteArray atomRequest = new AtomFromByteArray(ms.ToArray());
                RequestBatch requestBatch = new RequestBatch();
                
                Object ctx;
                ProtocolVersion protocolVersion;
                requestBatch.DeserializeInputFromProtocol(atomRequest, out ctx, out protocolVersion);
                cobaltFile.CobaltEndpoint.ExecuteRequestBatch(requestBatch);
                cobaltFile.CommitChanges();
                var response = requestBatch.SerializeOutputToProtocol(protocolVersion);
                context.Response.Headers.Add("X-WOPI-MachineName", "test");
                context.Response.Headers.Add("X-WOPI-CorellationID", context.Request.Headers["X-WOPI-CorrelationID"]);
                context.Response.Headers.Add("request-id", context.Request.Headers["X-WOPI-CorrelationID"]);
                context.Response.ContentType = @"application/octet-stream";
                context.Response.ContentLength64 = response.Length;
                response.CopyTo(context.Response.OutputStream);
                context.Response.Close();
            }

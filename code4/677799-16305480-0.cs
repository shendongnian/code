        appHost.ResponseFilters.Add((httpReq, httpRes, dto) =>
        {
            if (httpReq.ResponseContentType == ContentType.MsgPack)
            {
                using (var ms = new MemoryStream())
                {
                    var serializer = MessagePackSerializer.Create(dto.GetType());
                    serializer.PackTo(Packer.Create(ms), dto);
                    var bytes = ms.ToArray();
                    var listenerResponse = (HttpListenerResponse)httpRes.OriginalResponse;
                    listenerResponse.OutputStream.Write(bytes, 0, bytes.Length);
                    httpRes.EndServiceStackRequest();
                }
            }
        });

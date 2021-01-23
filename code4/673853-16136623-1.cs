    public GetContentResponse GetContent(abcServiceClient client, QueryPresentationElementIDsResponse querypresentationelementresponse)
            {
                GetContentRequest GetContentRequest = new GetContentRequest();
                GetContentResponse contentresponse = new GetContentResponse();
                querypresentationelementresponse = presentationElementId(client);
                List<string> chunks = new List<string>();
                for (int i = 0; i < querypresentationelementresponse.IDs.Length; i += 25)
                {
                    chunks.AddRange(querypresentationelementresponse.IDs.Skip(i).Take(25));
                    contentresponse = client.GetContent(new GetContentRequest()
                    {
                        IDs = chunks.ToArray()
                    });
                }
    
                return contentresponse;
            }

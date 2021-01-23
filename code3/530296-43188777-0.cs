            return new System.Web.Http.Results.ResponseMessageResult(
                new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new JsonContent($"{JsonConvert.SerializeObject(contact, Formatting.Indented)}")
                });

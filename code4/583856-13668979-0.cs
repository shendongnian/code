        public static System.ServiceModel.Channels.Message GetJsonStream(this object obj)
        {
            //Serialize JSON.NET
            string jsonSerialized = JsonConvert.SerializeObject(obj);
            //Create memory stream
            MemoryStream memoryStream = new MemoryStream(new UTF8Encoding().GetBytes(jsonSerialized));
            //Set position to 0
            memoryStream.Position = 0;
            //return Message
            return WebOperationContext.Current.CreateStreamResponse(memoryStream, "application/json");
        }

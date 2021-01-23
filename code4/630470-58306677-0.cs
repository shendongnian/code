    [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string loginOne(string param1, string param2){
              result = new JObject();
              ...
              ...
              return result.ToString();
        }

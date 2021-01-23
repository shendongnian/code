        var client = new RestClient("https://upload.box.com/api/2.0");
        var request = new RestRequest("files/content", Method.POST);
        request.AddParameter("parent_id", folder_id);
        request.AddHeader("Authorization", "Bearer " + accessToken);
        string path = @"D:\Project\21Teach\Documents\screenshots.docx";
        byte[] byteArray = System.IO.File.ReadAllBytes(path);
        request.AddFile("filename", byteArray, "screenshots.docx");
        var responses = client.Execute(request);
        var content = responses.Content;
    }
    static string folderCreation(string APIKey, string authToken)
    {
        
        RestClient client = new RestClient();
        client.BaseUrl = "https://api.box.com/2.0/folders";
        var request = new RestRequest(Method.POST);
        string Headers = string.Format("Bearer {0}", authToken);
        request.AddHeader("Authorization", Headers);
        request.AddParameter("application/json", "{\"name\":\"Youka\",\"parent\":{\"id\":\"0\"}}", ParameterType.RequestBody);
        var response = client.Execute(request);
        return response.Content;
       
      
       
    }

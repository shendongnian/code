    [Route("api/Video/AddNewVideo")]
    [System.Web.Http.HttpPost]
    public HttpResponseMessage AddNewVideo(JArray listvideoFromUser){
        if (listvideoFromUser.Count > 0){
            //DeserializeObject: that object you sent from client to server side. 
            //Note:VideoModels is class object same as model of client side
            VideoModels video = JsonConvert.DeserializeObject<VideoModels>(listvideoFromUser[0].ToString());
            //that is just method to save database
            Datacommons.AddNewVideo(video);
                    
            //show status for client
            HttpResponseMessage response = new HttpResponseMessage { StatusCode = HttpStatusCode.Created };
            return response;
        }
        else{
            HttpResponseMessage response = new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError };
            return response;
        }
    }

     public class UploadUserPhotoController : ApiController
    {
        
        /// <summary>
        /// </summary>
        /// <param name="request">
        /// HttpRequestMessage, on the other hand, is new in .NET 4.5. 
        /// It is part of System.Net. 
        /// It can be used both by clients and services to create, send and receive requests and 
        /// responses over HTTP. 
        /// It replaces HttpWebRequest, which is obsolete in .NET 4.5 
        /// </param>
        /// <returns>return the response of the Page <returns>
        [HttpPost]
        public async Task<HttpResponseMessage> Post(HttpRequestMessage request)
        {
            
            var httpRequest = HttpContext.Current.Request;
            var UploadUserFileObj = new UploadUserFile
            {
                Token = request.GetQueryNameValuePairs().AsEnumerable().Where(x => x.Key == "Token").FirstOrDefault().Value.ToString(),
                UserId = request.GetQueryNameValuePairs().AsEnumerable().Where(x => x.Key == "UserId").FirstOrDefault().Value.ToString(),
                IPAddress = request.GetQueryNameValuePairs().AsEnumerable().Where(x => x.Key == "IPAddress").FirstOrDefault().Value.ToString(),
                ContentType = request.GetQueryNameValuePairs().AsEnumerable().Where(x => x.Key == "ContentType").FirstOrDefault().Value.ToString(),
                DeviceInfo = request.GetQueryNameValuePairs().AsEnumerable().Where(x => x.Key == "DeviceInfo").FirstOrDefault().Value.ToString(),
                FileName = request.GetQueryNameValuePairs().AsEnumerable().Where(x => x.Key == "FileName").FirstOrDefault().Value.ToString()
            };
            Stream requestStream = await request.Content.ReadAsStreamAsync();
            HttpResponseMessage result = null;
            if (requestStream!=null)
            {
                try
                {
                    if(string.IsNullOrEmpty(UploadUserFileObj.FileName))
                    {
                        UploadUserFileObj.FileName = "DefaultName.jpg";
                    }
                    // Create a FileStream object to write a stream to a file
                    using (FileStream fileStream = System.IO.File.Create(HttpContext.Current.Server.MapPath("~/locker/" + UploadUserFileObj.FileName), (int)requestStream.Length))
                    {
                        // Fill the bytes[] array with the stream data
                        byte[] bytesInStream = new byte[requestStream.Length];
                        requestStream.Read(bytesInStream, 0, (int)bytesInStream.Length);
                        // Use FileStream object to write to the specified file
                        fileStream.Write(bytesInStream, 0, bytesInStream.Length);
                        result = Request.CreateResponse(HttpStatusCode.Created, UploadUserFileObj.FileName);
                    }
                }
                catch (HttpException ex)
                {
                    return result = Request.CreateResponse(HttpStatusCode.BadGateway,"Http Exception Come"+ ex.Message);
                }
                catch(Exception ex)
                {
                    return result = Request.CreateResponse(HttpStatusCode.BadGateway, "Http Exception Come" + ex.Message);
                }
            }
            else
            {
                return result = Request.CreateResponse(HttpStatusCode.BadGateway, "Not eble to upload the File ");
            }
            return result;
        }
    }

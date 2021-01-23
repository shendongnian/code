    public class VerifyShopifyAttribute : ActionFilterAttribute
    {
        private readonly string sharedSecret = "abc";
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!ValidateHash(actionContext))
            {
                // reject the request with a 400 error
                var response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
                actionContext.Response = response;
            }
        }
        private bool ValidateHash(HttpActionContext actionContext)
        {
            var context = (HttpContextBase)actionContext.Request.Properties["MS_HttpContext"];
            context.Request.InputStream.Seek(0, SeekOrigin.Begin);
            using (var stream = new MemoryStream())
            {
                context.Request.InputStream.CopyTo(stream);
                string requestBody = Encoding.UTF8.GetString(stream.ToArray());
                var keyBytes = Encoding.UTF8.GetBytes(sharedSecret);
                var dataBytes = Encoding.UTF8.GetBytes(requestBody);
                //use the SHA256Managed Class to compute the hash
                var hmac = new HMACSHA256(keyBytes);
                var hmacBytes = hmac.ComputeHash(dataBytes);
                //retun as base64 string. Compared with the signature passed in the header of the post request from Shopify. If they match, the call is verified.
                var hmacHeader = HttpContext.Current.Request.Headers["x-shopify-hmac-sha256"];
                var createSignature = Convert.ToBase64String(hmacBytes);
                return hmacHeader == createSignature;
            }
        }
    }
    

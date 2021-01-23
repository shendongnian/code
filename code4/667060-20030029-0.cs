        /// <summary>
        /// Get ip address from request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string GetIpAddress(HttpRequest request)
        {
            if (request.ServerVariables.IsNull()) return null;
            var _realAddress = request.ServerVariables[@"HTTP_X_FORWARDED_FOR"];
            if (_realAddress.IsNullOrEmpty())
            {
                _realAddress = request.ServerVariables[@"HTTP_FORWARDED"];
            }
            if (_realAddress.IsNullOrEmpty())
            {
                _realAddress = request.ServerVariables[@"REMOTE_ADDR"];
            }
            return _realAddress;
        }

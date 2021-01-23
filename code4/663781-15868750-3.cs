        private long ExtractPlayerIdFromHeader()
        {
            try
            {
                var opContext = OperationContext.Current;
                var requestContext = opContext.RequestContext;
                var headers = requestContext.RequestMessage.Headers;
                int headerIndex = headers.FindHeader("PlayerId", "");
                long playerId = headers.GetHeader<long>(headerIndex);
                return playerId;
            }
            catch (Exception ex)
            {
                this.Log.Error("Exception thrown when extracting the player id from the header", ex);
                throw;
            }
        }

    /// <summary>
        /// Determines whether the host should buffer the <see cref="HttpResponseMessage"/> entity body.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/>response for which to determine
        /// whether host output buffering should be used for the response entity body.</param>
        /// <returns><c>true</c> if buffering should be used; otherwise a streamed response should be used.</returns>
        public virtual bool UseBufferedOutputStream(HttpResponseMessage response)
        {
            if (response == null)
            {
                throw Error.ArgumentNull("response");
            }
            // Any HttpContent that knows its length is presumably already buffered internally.
            HttpContent content = response.Content;
            if (content != null)
            {
                long? contentLength = content.Headers.ContentLength;
                if (contentLength.HasValue && contentLength.Value >= 0)
                {
                    return false;
                }
                // Content length is null or -1 (meaning not known).  
                // Buffer any HttpContent except StreamContent and PushStreamContent
                return !(content is StreamContent || content is PushStreamContent);
            }
            return false;
        }

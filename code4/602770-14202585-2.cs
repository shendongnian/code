        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, string mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/xml");
        }

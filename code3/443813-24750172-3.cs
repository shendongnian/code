        [HttpDelete]
        [ArrayInput("tagIDs", typeof(Guid))]
        [Route("api/v1/files/{fileID}/tags/{tagIDs}")]
        public HttpResponseMessage RemoveFileTag(Guid fileID, Guid[] tagIDs)
        {
            _FileRepository.RemoveTag(fileID, tagIDs);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

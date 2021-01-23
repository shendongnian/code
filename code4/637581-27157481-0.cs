        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id){
            await _snippetService.DeleteComment(id);
            return Ok();
        }

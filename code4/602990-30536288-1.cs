    // /api/SizeSequence/5
    public async Task<IHttpActionResult> PostSaveSizeSequence(int? Id, List<String> IncludedSizes)
        {
            if (Id == null || IncludedSizes == null || IncludedSizes.Exists( s => String.IsNullOrWhiteSpace(s)))
                return BadRequest();
            try
            {
               
                await this.Repo.SaveSizeSequenceAsync(Id.Value, IncludedSizes );
                return Ok();
            }
            catch ( Exception exc)
            {
                return Conflict();
            }
        }

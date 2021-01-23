    /// <summary>
    /// Deletes a list of items.
    /// </summary>
    /// <param name="itemIds">The list of unique identifiers for the  items.</param>
    /// <returns>The deleted item.</returns>
    /// <response code="201">The item was successfully deleted.</response>
    /// <response code="400">The item is invalid.</response>
    [HttpDelete("{itemIds}", Name = ItemControllerRoute.DeleteItems)]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task Delete(List<int> itemIds)
    => await _itemAppService.RemoveRangeAsync(itemIds);

    [HttpPost]
    public IActionResult Delete(string id)
    {
    	ObjectId objectId = ObjectId.Parse(id);
    	DbContext.Users.DeleteOne(x => x.Id == objectId);
    	return null;
    }

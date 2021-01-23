    public IEnumerable<IElement> GetType(int id, int userId, int modelId, int depth = 2)
    {
        using (var db = database.connection)
        {
            var _results = db.table<_ElementBase>(id, userId, modelId, 
                     IElementExtensions.IElementFactory(), depthLevel: depth);
            return _results.FilterByPermissions(userId);
        }
    }

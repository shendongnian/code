    public static void AssignContentToNewPlaceHoldersWithinPage(Page pPage, string pOldId, string pNewId)
    {
        if (pPage == null || string.IsNullOrEmpty(pOldId) || string.IsNullOrEmpty(pNewId))
        {
            return;
        }
        // Try to get a reference to private hashtable using fasterflect free reflection library in codeplex (http://fasterflect.codeplex.com/)
        // you can replace following line with standard reflection APIs
        var lTmpObj = pPage.TryGetFieldValue("_contentTemplateCollection");
        if (lTmpObj != null && lTmpObj is Hashtable)
        {
            var _contentTemplateCollection = lTmpObj as Hashtable;
            if (_contentTemplateCollection.ContainsKey(pOldId) && !_contentTemplateCollection.ContainsKey(pNewId))
            {
                var lTemplate = _contentTemplateCollection[pOldId];
                _contentTemplateCollection.Add(pNewId, lTemplate);
                _contentTemplateCollection.Remove(pOldId);
            }
        }
    }

    public static List<AssignmentContentItem> DeserializeAssignmentContent(string jsonContent)
    {
        return JsonConvert.DeserializeObject<List<AssignmentContentItem>>(jsonContent, new JsonSerializerSettings
        { 
                DefaultValueHandling = DefaultValueHandling.Populate, 
                NullValueHandling = NullValueHandling.Ignore 
        });
    }

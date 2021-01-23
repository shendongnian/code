    private static string GetJsonDiff(string action, string existing, string modified, string objectType)
        {
            // convert JSON to object
            JObject xptJson = JObject.Parse(modified);
            JObject actualJson = JObject.Parse(existing);
            // read properties
            var xptProps = xptJson.Properties().ToList();
            var actProps = actualJson.Properties().ToList();
            // find differing properties
            var auditLog = (from existingProp in actProps
                from modifiedProp in xptProps
                where modifiedProp.Path.Equals(existingProp.Path)
                where !modifiedProp.Value.Equals(existingProp.Value)
                select new AuditLog
                {
                    Field = existingProp.Path,
                    OldValue = existingProp.Value.ToString(),
                    NewValue = modifiedProp.Value.ToString(),
                    Action = action, ActionBy = GetUserName(),
                    ActionDate = DateTime.UtcNow.ToLongDateString(),
                    ObjectType = objectType
                }).ToList();
            return JsonConvert.SerializeObject(auditLog);
        }

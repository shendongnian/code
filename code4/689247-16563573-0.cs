    var text = normalComment.GetName();
 
    public static class EnumExtension
    {
            public static string GetName(this eCommentType type)
            {
                return Strings.ResourceManager.GetString(type.ToString());
            }
    }

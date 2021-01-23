    public class RequiredOnAttribute : ValidationAttribute
    {
        public string[] URLs { get; set; }
        public override bool IsValid(object value)
        {
            if (URLs.Contains(System.Web.HttpContext.Current.Request.Url.AbsolutePath))
            {
                if (string.IsNullOrEmpty(value as string))
                {
                    return false;
                }
            }
            return true;
        }
    }

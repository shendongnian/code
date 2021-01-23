    Ctx.Request["okPress"] = bool.TryParseCustom(Ctx.Request["okPress"]);
    public static class ConvertionExtension
    {
        public static bool TryParseCustom(this bool convert, string expression)
        {
            bool valid;
            try
            {
               bool.TryParse(expression, out valid);
            }
            catch (Exception)
            {
                valid = false;
            }
            return valid;
        }
    }

        public static bool TryParseAsBoolean(this string expression)
        {
            bool booleanValue;
            bool.TryParse(expression, out booleanValue);
            return booleanValue;
        }
        bool okPress =  Ctx.Request["okPress"].TryParseAsBoolean();

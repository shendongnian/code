        public static bool CheckTags(string tags)
        {
            if (!Regex.IsMatch(tags, @"^(|[\w-]{1,30}(,\s?[\w-]{1,30}){0,8}(,\s?)?)$"))
                return false;
            // Step 1: Check duplicated tags
            // Step 1.1: Remove the whitespace first
            tags = Regex.Replace(tags, @"\s+", @"");
            string[] tagsArray = tags.Split(',');
            // Step 1.2: Check if duplicated items exist
            if (tagsArray.Distinct().Count() != tagsArray.Length)
                return false;
            return true;
        }

        private static readonly Regex CompiledRegex = new Regex("^[a-zA-Z]+-", RegexOptions.Compiled);
        private static string GetNameCompiled(string objString)
        {
            return CompiledRegex.Replace(objString, "");
        }

    public class CommentConvention : Convention
    {
        public const string NewLinePlaceholder = "<<NEWLINE>>";
        public CommentConvention()
        {
            var docuXml = new XmlDocument();
            // Read the documentation xml
            using (var commentStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Namespace.Documentation.xml"))
            {
                docuXml.Load(commentStream);
            }
            // configure class/table comment
            Types()
                .Having(pi => docuXml.SelectSingleNode($"//member[starts-with(@name, 'T:{pi?.FullName}')]/summary"))
                .Configure((c, a) =>
                {
                    c.HasTableAnnotation("Comment", GetCommentTextWithNewlineReplacement(a));
                });
            // configure property/column comments
            Properties()
                .Having(pi =>
                    docuXml.SelectSingleNode(
                        $"//member[starts-with(@name, 'P:{pi?.DeclaringType?.FullName}.{pi?.Name}')]/summary"))
                .Configure((c, a) => { c.HasColumnAnnotation("Comment", GetCommentTextWithNewlineReplacement(a)); });
        }
        // adjust the documentation text to handle newline and whitespace
        private static string GetCommentTextWithNewlineReplacement(XmlNode a)
        {
            if (string.IsNullOrWhiteSpace(a.InnerText))
            {
                return null;
            }
            return string.Join(
                NewLinePlaceholder,
                a.InnerText.Trim()
                    .Split(new string[] {"\r\n", "\r", "\n"}, StringSplitOptions.None)
                    .Select(line => line.Trim()));
        }
    }

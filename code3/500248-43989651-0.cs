    public static partial class XmlNodeExtensions
    {
        /// <summary>
        /// Returns all immediate text values of the given node, concatenated into a string
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static string SelfInnerText(this XmlNode node)
        {
            // Adapted from http://referencesource.microsoft.com/#System.Xml/System/Xml/Dom/XmlNode.cs,66df5d2e6b0bf5ae,references
            if (node == null)
                return null;
            else if (node is XmlProcessingInstruction || node is XmlDeclaration || node is XmlCharacterData)
            {
                // These are overridden in the reference source.
                return node.InnerText;
            }
            else
            {
                var firstChild = node.FirstChild;
                if (firstChild == null)
                    return string.Empty;
                else if (firstChild.IsNonCommentText() && firstChild.NextSibling == null)
                    return firstChild.InnerText; // Optimization.
                var builder = new StringBuilder();
                for (var child = firstChild; child != null; child = child.NextSibling)
                {
                    if (child.IsNonCommentText())
                        builder.Append(child.InnerText);
                }
                return builder.ToString();
            }
        }
        /// <summary>
        /// Enumerates all immediate text values of the given node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static IEnumerable<string> SelfInnerTexts(this XmlNode node)
        {
            // Adapted from http://referencesource.microsoft.com/#System.Xml/System/Xml/Dom/XmlNode.cs,66df5d2e6b0bf5ae,references
            if (node == null)
                yield break;
            else if (node is XmlProcessingInstruction || node is XmlDeclaration || node is XmlCharacterData)
            {
                // These are overridden in the reference source.
                yield return node.InnerText;
            }
            else
            {
                var firstChild = node.FirstChild;
                for (var child = firstChild; child != null; child = child.NextSibling)
                {
                    if (child.IsNonCommentText())
                        yield return child.InnerText;
                }
            }
        }
        public static bool IsNonCommentText(this XmlNode node)
        {
            return node != null &&
                (node.NodeType == XmlNodeType.Text || node.NodeType == XmlNodeType.CDATA
                || node.NodeType == XmlNodeType.Whitespace || node.NodeType == XmlNodeType.SignificantWhitespace);
        }
    }

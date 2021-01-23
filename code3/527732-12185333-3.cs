    public static IEnumerable<OpenXmlElement> SiblingsUntilCommentRangeEnd(CommentRangeStart commentStart)
    {
        List<OpenXmlElement> commentedNodes = new List<OpenXmlElement>();
        OpenXmlElement element = commentStart;
        while (true)
        {
            element = element.NextSibling();
            // check that the item exists
            if (element == null)
            {
                break;
            }
            //check that the item is matching comment end
            if (IsMatchingCommentEnd(element, commentStart.Id.Value))
            {
                break;
            }
            //check that there is a matching element in the current element's descendants
            var descendantsCommentEnd = element.Descendants<CommentRangeEnd>();
            if (descendantsCommentEnd != null)
            {
                foreach (CommentRangeEnd rangeEndNode in descendantsCommentEnd)
                {
                    if (IsMatchingCommentEnd(rangeEndNode, commentStart.Id.Value))
                    {
                        //matching range end element found in current element's descendants
                        //an improvement could be made here to manually select descendants before CommentRangeEnd node
                        break;
                    }
                }
            }
            commentedNodes.Add(element);
        }
        return commentedNodes;
    }

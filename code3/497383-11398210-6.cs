    using System;
    using System.Collections.Generic;
    using umbraco.cms.businesslogic.web;
    namespace Example
    {
        static class Extensions
        {
            public static IEnumerable<Document> GetDescendants(this Document document)
            {
                foreach (Document child in document.Children)
                {
                    yield return child;
                    foreach (Document grandChild in child.GetDescendants())
                    {
                        yield return grandChild;
                    }
                }
                yield break;
            }
        }
    }

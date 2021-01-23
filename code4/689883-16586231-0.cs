        private static bool AreEquivalent(XElement a, XElement b)
        {
            if (a.Name != b.Name) return false;
            if (!a.HasAttributes && !b.HasAttributes) return true;
            if (!a.HasAttributes || !b.HasAttributes) return false;
            if (a.Attributes().Count() != b.Attributes().Count()) return false;
            return a.Attributes().All(attA => b.Attributes(attA.Name)
                .Count(attB => attB.Value == attA.Value) != 0);
        }
        private static void MergeElements(XElement mergeDocument, XElement source)
        {
            // merge per-element content from parentB into parentA
            //
            foreach (var childSource in source.DescendantNodes())
            {
                // merge childB with first equivalent childA
                // equivalent childB1, childB2,.. will be combined
                //
                bool isMatchFound = false;
                if (!(childSource is XElement))
                {
                    continue;
                }
                foreach (var childMerged in mergeDocument.Descendants())
                {
                    if (!(childMerged is XElement))
                    {
                        continue;
                    }
                    if (AreEquivalent((XElement)childMerged, (XElement)childSource))
                    {
                        MergeElements((XElement)childMerged, (XElement)childSource);
                        isMatchFound = true;
                        break;
                    }
                }
                // if there is no equivalent childA, add childB into parentA
                //
                if (!isMatchFound) mergeDocument.Add(childSource);
            }
        }

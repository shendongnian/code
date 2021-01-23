    public static void MergeInto(
        this JContainer left, JToken right, MergeOptions options)
    {
        foreach (var rightChild in right.Children<JProperty>())
        {
            var rightChildProperty = rightChild;
            var leftPropertyValue = left.SelectToken(rightChildProperty.Name);
            if (leftPropertyValue == null)
            {
                // no matching property, just add 
                left.Add(rightChild);
            }
            else
            {
                var leftProperty = (JProperty) leftPropertyValue.Parent;
                var leftArray = leftPropertyValue as JArray;
                var rightArray = rightChildProperty.Value as JArray;
                if (leftArray != null && rightArray != null)
                {
                    switch (options.ArrayHandling)
                    {
                        case MergeOptionArrayHandling.Concat:
                            foreach (var rightValue in rightArray)
                            {
                                leftArray.Add(rightValue);
                            }
                            break;
                        case MergeOptionArrayHandling.Overwrite:
                            leftProperty.Value = rightChildProperty.Value;
                            break;
                    }
                }
                else
                {
                    var leftObject = leftPropertyValue as JObject;
                    if (leftObject == null)
                    {
                        // replace value
                        leftProperty.Value = rightChildProperty.Value;
                    }
                    else
                        // recurse object
                        MergeInto(leftObject, rightChildProperty.Value, options);
                }
            }
        }
    }

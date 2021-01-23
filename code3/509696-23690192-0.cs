    using System.Collections;
    using System.Resources;
    /// <summary>   Resource item. </summary>
    public static class ResourceItem
    {
        /// <summary>
        /// This routine is responsible for getting all the comments from the original files and then
        /// adding them to the new resource files.
        /// </summary>
        /// <param name="inputResX">    The path to the source resx. </param>
        /// <param name="outputResX">   The path to the destination resx. </param>
        /// <returns>   True if changes were made. </returns>
        public static bool CopyComments(string inputResX, string outputResX)
        {
            bool changesMade = false;
            // Populate a Hashtable containing the DataNodes in the output file
            var output = new Hashtable();
            using (var reader = new ResXResourceReader(outputResX))
            {
                reader.UseResXDataNodes = true;
                IEnumerator enumerator = reader.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var entry = (DictionaryEntry)enumerator.Current;
                    var dataNode = (ResXDataNode)entry.Value;
                    output.Add(dataNode.Name, dataNode);
                }
            }
            // Search the Hashtable for equivalent DataNodes in the input file
            using (var reader = new ResXResourceReader(inputResX))
            {
                reader.UseResXDataNodes = true;
                IEnumerator enumerator = reader.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var entry = (DictionaryEntry)enumerator.Current;
                    var inputDataNode = (ResXDataNode)entry.Value;
                    if (output.ContainsKey(inputDataNode.Name))
                    {
                        var outputDataNode = (ResXDataNode)output[inputDataNode.Name];
                        if (!string.IsNullOrEmpty(inputDataNode.Comment) && outputDataNode.Comment != inputDataNode.Comment)
                        {
                            // Update the output resx’s comments with the input resx’s comments
                            outputDataNode.Comment = inputDataNode.Comment;
                            changesMade = true;
                        }
                    }
                }
            }
            if (changesMade)
            {
                // Write the changes back to the output file
                using (var writer = new ResXResourceWriter(outputResX))
                {
                    foreach (DictionaryEntry entry in output)
                    {
                        writer.AddResource(entry.Key.ToString(), entry.Value);
                    }
                    writer.Generate();
                    writer.Close();
                }
            }
            return changesMade;
        }
    }

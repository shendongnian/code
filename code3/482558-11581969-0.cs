	ResXResourceReader readerData = new ResXResourceReader(new StringReader(sw.ToString()));
	ResXResourceReader readerMetaData = new ResXResourceReader(new StringReader(sw.ToString()));
	//Flag to read nodes as ResXDataNode, instead of key/value pairs, to preserve Comments.
	readerData.UseResXDataNodes = true;
	ResXResourceWriter writer = new ResXResourceWriter(this.FilePath);
	foreach (DictionaryEntry resEntry in readerData)
	{
		ResXDataNode node = resEntry.Value as ResXDataNode;
		if (node != null)
		{
			DictionaryEntry metaDataEntry;
			//Check if node is metadata. The reader does not distinguish between 
			//data and metadata when UseResXDataNodes flags is set to true.
			//http://connect.microsoft.com/VisualStudio/feedback/details/524508/resxresourcereader-does-not-split-data-and-metadata-entries-when-useresxdatanodes-is-true
			if (IsMetaData(readerMetaData, resEntry, out metaDataEntry))
			{
				writer.AddMetadata(metaDataEntry.Key.ToString(), metaDataEntry.Value);
			}
			else
			{
				writer.AddResource(node);
			}
		}	
	}
	writer.Generate(); //write to the file
	writer.Close();
	readerData.Close();
	readerMetaData.Close();
----------
	/// <summary>
	/// Check if resource data is metadata. If so, return the metadata node.
	/// </summary>
	/// <param name="metaDataReader"></param>
	/// <param name="resEntry"></param>
	/// <param name="metaData"></param>
	/// <returns></returns>
	private static bool IsMetaData(ResXResourceReader metaDataReader, DictionaryEntry resEntry, out DictionaryEntry metaData)
	{
		IDictionaryEnumerator metadataEnumerator = metaDataReader.GetMetadataEnumerator();
		while (metadataEnumerator.MoveNext())
		{
			if (metadataEnumerator.Entry.Key.Equals(resEntry.Key))
			{
				metaData = metadataEnumerator.Entry;
				return true;
			}
		}
		return false;
	}

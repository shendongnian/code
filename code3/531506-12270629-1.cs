    public async Task SaveAsync(T Obj)
    {
    	if (Obj == null)
    		throw new ArgumentNullException("Obj");
    	
    	StorageFile file = null;
    	StorageFolder folder = GetFolder(storageType);
    	file = await folder.CreateFileAsync(FileName(Obj), CreationCollisionOption.ReplaceExisting);
    	
    	IRandomAccessStream writeStream = await file.OpenAsync(FileAccessMode.ReadWrite);
    	using (Stream outStream = Task.Run(() => writeStream.AsStreamForWrite()).Result)
    	{
    		try
    		{
    			serializer.Serialize(outStream, Obj);
    		}
    		catch (InvalidOperationException ex)
    		{
    			throw new TypeNotSerializableException(typeof(T), ex);
    		}
    		
    		await outStream.FlushAsync();
    	}
    }

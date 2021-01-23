		using System.IO;
		using System.Reflection;
		namespace MyProject.Video
		{
			class MyVideoClass
			{
				private const string videoExtract = "MyProject.Video.MyVideo.dat";      
			   
				public byte[] GetStream()
				{
					try
					{
						var memoryStream = new MemoryStream();
						Stream sourceStream = null;
						sourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(videoExtract); 
						if (sourceStream != null) sourceStream.CopyTo(memoryStream);
						return memoryStream.ToArray();
					}
					catch
					{
						return null;
					}
				}
			}
		}

        public class DeCompressedContent : HttpContent
	{
		private HttpContent originalContent;
		private string encodingType;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="content"></param>
		/// <param name="encodingType"></param>
		public DeCompressedContent(HttpContent content, string encodingType)
		{
			if (content == null) throw new ArgumentNullException("content");
			if (string.IsNullOrWhiteSpace(encodingType)) throw new ArgumentNullException("encodingType");
			this.originalContent = content;
			this.encodingType = encodingType.ToLowerInvariant();
			if (!this.encodingType.Equals("gzip", StringComparison.CurrentCultureIgnoreCase) && !this.encodingType.Equals("deflate", StringComparison.CurrentCultureIgnoreCase))
			{
				throw new InvalidOperationException(string.Format("Encoding {0} is not supported. Only supports gzip or deflate encoding", this.encodingType));
			}
			foreach (KeyValuePair<string, IEnumerable<string>> header in originalContent.Headers)
			{
				this.Headers.TryAddWithoutValidation(header.Key, header.Value);
			}
			this.Headers.ContentEncoding.Add(this.encodingType);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
		{
			var output = new MemoryStream();
			return this.originalContent
				.CopyToAsync(output).ContinueWith(task =>
				{
					// go to start
					output.Seek(0, SeekOrigin.Begin);
					if (this.encodingType.Equals("gzip", StringComparison.CurrentCultureIgnoreCase))
					{
						using (var dec = new GZipStream(output, CompressionMode.Decompress))
						{
							dec.CopyTo(stream);
						}
					}
					else
					{
						using (var def = new DeflateStream(output, CompressionMode.Decompress))
						{
							def.CopyTo(stream);
						}
					}
					if (output != null)
						output.Dispose();
				});
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		protected override bool TryComputeLength(out long length)
		{
			length = -1;
			return (false);
		}
	}

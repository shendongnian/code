    string base64SegmentFromUrl; // from incoming web request to profile page
    Guid userGuid = new Guid(FromBase64WebSafeString(base64SegmentFromUrl);
		/// <summary>
		/// Decodes a (web-safe) base64-string back to its binary buffer form.
		/// </summary>
		/// <param name="base64WebSafe">The base64-encoded string.  May be web-safe encoded.</param>
		/// <returns>A data buffer.</returns>
		internal static byte[] FromBase64WebSafeString(string base64WebSafe) {
			Requires.NotNullOrEmpty(base64WebSafe, "base64WebSafe");
			Contract.Ensures(Contract.Result<byte[]>() != null);
			// Restore the padding characters and original URL-unsafe characters.
			int missingPaddingCharacters;
			switch (base64WebSafe.Length % 4) {
				case 3:
					missingPaddingCharacters = 1;
					break;
				case 2:
					missingPaddingCharacters = 2;
					break;
				case 0:
					missingPaddingCharacters = 0;
					break;
				default:
					throw ErrorUtilities.ThrowInternal("No more than two padding characters should be present for base64.");
			}
			var builder = new StringBuilder(base64WebSafe, base64WebSafe.Length + missingPaddingCharacters);
			builder.Replace('-', '+').Replace('_', '/');
			builder.Append('=', missingPaddingCharacters);
			return Convert.FromBase64String(builder.ToString());
		}

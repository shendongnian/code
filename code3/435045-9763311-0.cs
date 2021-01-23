    Guid userGuid; // value comes from your database
    ConvertToBase64WebSafeString(userGuid.ToByteArray());
		/// <summary>
		/// Converts to data buffer to a base64-encoded string, using web safe characters and with the padding removed.
		/// </summary>
		/// <param name="data">The data buffer.</param>
		/// <returns>A web-safe base64-encoded string without padding.</returns>
		internal static string ConvertToBase64WebSafeString(byte[] data) {
			var builder = new StringBuilder(Convert.ToBase64String(data));
			// Swap out the URL-unsafe characters, and trim the padding characters.
			builder.Replace('+', '-').Replace('/', '_');
			while (builder[builder.Length - 1] == '=') { // should happen at most twice.
				builder.Length -= 1;
			}
			return builder.ToString();
		}

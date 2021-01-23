	public class CaseAccentInsensitiveEqualityComparer : IEqualityComparer<string>
	{
		public bool Equals(string x, string y)
		{
			return string.Compare(x, y, CultureInfo.InvariantCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0;
		}
		public int GetHashCode(string obj)
		{
			if (obj == null) throw new ArgumentNullException("obj");
			return RemoveDiacritics(obj).ToUpperInvariant().GetHashCode();
		}
		private string RemoveDiacritics(string text)
		{
			return string.Concat(
				text.Normalize(NormalizationForm.FormD)
				.Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
											  UnicodeCategory.NonSpacingMark)
			  ).Normalize(NormalizationForm.FormC);
		}
	}

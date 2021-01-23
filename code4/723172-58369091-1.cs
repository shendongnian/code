private static string SlowButStrong(decimal v)
{
  if( v % 1 == 0) return v.ToString(); // If no decimal digits, let's leave it alone
  var withNoZeroes = v.ToString().TrimEnd('0');
  return withNoZeroes.EndsWith('.') ? withNoZeroes + "00" : withNoZeroes;
}
## Test output
Input 123M, expecting 123
✅ G29: 123
✅ : 123
✅ ⛵: 123
Input 123.00M, expecting 123.00
❌ G29: 123
✅ : 123.00
❌ ⛵: 123
Input 123.45M, expecting 123.45
✅ G29: 123.45
✅ : 123.45
✅ ⛵: 123.45
Input 123.450M, expecting 123.45
✅ G29: 123.45
✅ : 123.45
✅ ⛵: 123.45
Input 5.00000001M, expecting 5.00000001
✅ G29: 5.00000001
✅ : 5.00000001
✅ ⛵: 5.00000001
Input -0.00000000001M, expecting -0.00000000001
❌ G29: -1E-11
✅ : -0.00000000001
✅ ⛵: -0.00000000001
Input 10000000000000000000000M, expecting 10000000000000000000000
✅ G29: 10000000000000000000000
✅ : 10000000000000000000000
✅ ⛵: 10000000000000000000000
## Arbitrary test case
public static void Main(string[] args)
{
	Test("123M", 123M, "123");
	Test("123.00M", 123.00M, "123.00");
	Test("123.45M", 123.45M, "123.45");
	Test("123.450M", 123.450M, "123.45");
	Test("5.00000001M", 5.00000001M, "5.00000001");
	Test("-0.00000000001M", -0.00000000001M, "-0.00000000001");
	Test("10000000000000000000000M", 10000000000000000000000M, "10000000000000000000000");
}
private static void Test(string vs, decimal v, string expected)
{
	Console.OutputEncoding = System.Text.Encoding.UTF8;
	Console.WriteLine($"Input {vs}, expecting {expected}");
	Print("G29", v.ToString("G29"), expected);
	Print("", SlowButStrong(v), expected);
	Print("⛵", LessSlowButStrong(v), expected);
	Console.WriteLine();
}
private static void Print(string prefix, string formatted, string original)
{
	var mark = formatted == original ? "✅" : "❌"; 
	Console.WriteLine($"{mark} {prefix:10}: {formatted}");
}
private static string SlowButStrong(decimal v)
{
	if( v % 1 == 0) return v.ToString(); // If no decimal digits, let's leave it alone
	var withNoZeroes = v.ToString().TrimEnd('0');
	return withNoZeroes.EndsWith('.') ? withNoZeroes + "00" : withNoZeroes;
}
private static string LessSlowButStrong(decimal v)
{
	return v.ToString((v < 1) ? "" : "G29");
}

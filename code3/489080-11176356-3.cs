public static void Main()
{
	var sw = new Stopwatch();
	sw.Start();
	StringBuilder s = new StringBuilder();
	//string s = &quot;&quot;;
	int i;
	for (i = 0; sw.ElapsedMilliseconds &lt; 1000; ++i)
		//s += i.ToString();
		s.Append(i.ToString());
	sw.Stop();
	Console.WriteLine(&quot;using version with type &quot; + s.GetType().Name + &quot; I did &quot; +
		i + &quot; times of string concatenation.&quot;);
}</pre>

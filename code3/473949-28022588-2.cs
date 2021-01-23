csharp
static void Main(string[] args)
{
	//First create the main class:
	WolframAlpha wolfram = new WolframAlpha("APPID HERE");
	//Then you simply query Wolfram|Alpha like this
	//Note that the spelling error will be correct by Wolfram|Alpha
	QueryResult results = wolfram.Query("Who is Danald Duck?");
	//The QueryResult object contains the parsed XML from Wolfram|Alpha. Lets look at it.
	//The results from wolfram is split into "pods". We just print them.
	if (results != null)
	{
		foreach (Pod pod in results.Pods)
		{
			Console.WriteLine(pod.Title);
			if (pod.SubPods != null)
			{
				foreach (SubPod subPod in pod.SubPods)
				{
					Console.WriteLine(subPod.Title);
					Console.WriteLine(subPod.Plaintext);
				}
			}
		}
	}
}
For more examples, take a look at the WolframAlphaNet.Examples and WolframAlphaNet.Tests projects.

    // using Microsoft.AspNetCore.WebUtilities;
	var query = new Dictionary<string, string>
	{
		["foo"] = "bar",
		["foo2"] = "bar2",
		// ...
	};
	var response = await client.GetAsync(QueryHelpers.AddQueryString("/api/", query));

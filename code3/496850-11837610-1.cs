        using (var fdb = new FALDbContext())
        {
            var myList = fdb.Members
                                .Where(m => m.GenderShareWithId > 0)
                                .Select(m => new { m.MemberId, m.DisplayName, Places = m.Places.Where(p => p.PlaceName.StartsWith("L")).Select(p => p.PlaceName) });
            foreach (var item in myList)
            {
                Console.WriteLine(item.DisplayName);
                foreach (var place in item.Places)
                {
                    Console.WriteLine(" - " + place);
                }
            }
        }
    SELECT 
    	[Extent1].[MemberId] AS [MemberId], 
    	[Extent1].[DisplayName] AS [DisplayName], 
    	[Extent2].[PlaceName] AS [PlaceName]
    FROM  [dbo].[Members] AS [Extent1]
    LEFT OUTER JOIN [dbo].[Places] AS [Extent2] 
    	ON ([Extent1].[MemberId] = [Extent2].[Member_MemberId]) AND ([Extent2].[PlaceName] LIKE N'L%')
    WHERE [Extent1].[GenderShareWithId] > 0

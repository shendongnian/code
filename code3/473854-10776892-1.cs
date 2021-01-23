    var runningMins =   from weekNum in data
    					select new
    							   {
    								   FranchiseId = weekNum.FranchiseId,
    								   WeekEnding = weekNum.WeekEnding,
    								   Sales = weekNum.Sales,
    								   LastThreeWeeks = data.OrderByDescending( x => x.WeekEnding )
    										.Where( x => x.WeekEnding <= weekNum.WeekEnding )
    										.Take( 4 )
    										.Min( x => x.Sales )
    							   };

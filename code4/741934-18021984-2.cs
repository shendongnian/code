    var list = new [] { 
		new RoadTaxDto {LineId=122317,ItemDesc="None", ItemId=-1,RoadTax =26.63M  , VehicleId=-78603  ,Amount=300},
		new RoadTaxDto {LineId=122317,ItemDesc="None", ItemId=-2,RoadTax =17.75M  , VehicleId=-78603  ,Amount=200},
		new RoadTaxDto {LineId=122317,ItemDesc="None", ItemId=-1,RoadTax =22.19M  , VehicleId=-78602  ,Amount=250},
	    new RoadTaxDto {LineId=122317,ItemDesc="Deli", ItemId=-2,RoadTax =17.75M , VehicleId=-78603  ,Amount=200}
	};
													
	var query = (from c in list join x in list 
	on new { c.LineId, c.ItemId , c.VehicleId, c.Amount,c.RoadTax} equals new {x.LineId, x.ItemId, x.VehicleId,x.Amount,x.RoadTax}
	select new RoadTaxDto {
	   LineId = c.LineId,
	   ItemDesc = x.ItemDesc!="None"? x.ItemDesc:c.ItemDesc,
	   VehicleId=c.VehicleId,
	   Amount=c.Amount,
	   RoadTax=c.RoadTax,
	   ItemId=c.ItemId
	}
	).GroupBy(x => new { x.LineId, x.RoadTax, x.Amount, x.VehicleId} ).Select(grp => grp.Last());

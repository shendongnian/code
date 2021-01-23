    List<Travel> travels = logic.GetAllTravels();
    var _bind = from a in travels
    			select new
    			{
    				Servicename = a.Service.Name,
    				SourceName = a.Source.Name,
    				DestinyName = a.Destiny.Name,
    				Price = a.Price
    			};
    DgvRecorridos.DataSource = _bind;

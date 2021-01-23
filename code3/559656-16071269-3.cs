    @{
    var builder = new System.Text.StringBuilder();              
    foreach (var car in cars)
    {            
    builder.Append("{");
    builder.Append(Json.Encode("reg") + ":" + Json.Encode(car.Registration) + ",");
    builder.Append(Json.Encode("model") + ":" + car.Model);
    
    // INSERT OTHER VALUES HERE     
         
    builder.Append("}");
    if (car.Registration != cars.Last().Registration)
    {
    builder.Append(",");
    }
    count++;
    }
    }
    @Html.Raw(builder.ToString())

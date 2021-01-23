    string _InsertVehicleQuery = "INSERT INTO VSI_VehicleRecords(StockNumber,Status,Make,Model,Colour,Spefication) VALUES (@StockNumber, @Status, @Make, @Model, @Colour, @Specification);";
    
        SqlCommand _InsertVehicleCommand = new SqlCommand(_InsertVehicleQuery);
        _InsertVehicleCommand.Parameters.Add(new SqlParameter("@StockNumber", __StockNumber));
        _InsertVehicleCommand.Parameters.Add(new SqlParameter("@Status", __Status));
        _InsertVehicleCommand.Parameters.Add(new SqlParameter("@Make", Make));
        _InsertVehicleCommand.Parameters.Add(new SqlParameter("@Model", Model));
        _InsertVehicleCommand.Parameters.Add(new SqlParameter("@Colour", Colour));
        _InsertVehicleCommand.Parameters.Add(new SqlParameter("@Specification", Specification));

    class StatusPOCO { public int Status { get; set; } }
    class NormalPOCO : StatusPOCO { ... }
    class ErrorPOCO : StatusPOCO { ... }
    var response = await client.ExecuteAsync<StatusPOCO>(request);
    // restsharp's deserializer:
    IDeserializer deserializer = new JsonDeserializer();
    if (response.Data.status != 100)
       error = deserializer.Deserialize<ErrorPOCO>(response);
    else
       normal = deserializer.Deserialize<NormalPOCO>(response);

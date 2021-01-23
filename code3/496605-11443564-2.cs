    [HandleDarkWaterUIException]
    public JsonResult UpdateName(string objectToUpdate)
    {
       var response = myClient.ValidateObject(objectToUpdate);
       if (response.errors.Length > 0)
         throw new ValidationException(Json(response));
    }

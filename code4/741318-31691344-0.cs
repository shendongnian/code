    [HttpPost]
    public ActionResult ProcessModel(string modelName, string anyModel)
    {
       switch(modelName)  {
          case "Model1":
                 var modelValue= JsonDeserialize<Model1>(anyModel);
                  // do something 
               break;
         case "Model2": 
                var modelValue= JsonDeserialize<Model2>(anyModel); 
                // do something
               break;
        }
    }
                  

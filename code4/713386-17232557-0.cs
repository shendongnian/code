            JsonResult jsonResult = oemController.List() as JsonResult;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result result = serializer.Deserialize<Result>(serializer.Serialize(jsonResult.Data));
            public class Result 
            {
                public bool success ;
                public string error;
            }

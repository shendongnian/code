    public HttpResponseMessage Post([FromBody] string jsonData)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, jsonData);            
            try 
            {
                string jsonString = jsonData.ToString();
                JArray jsonVal = JArray.Parse(jsonString) as JArray;
                dynamic mylist= jsonVal;
                foreach (dynamic myitem in mylist)
                {
                    string strClave=string.Empty;
                    string strNum=string.Empty;
                    string strStatus=string.Empty;
                    strClave = myitem.clave;
                    strNum=myitem.num;
                    strStatus = myitem.status; 
                }
   

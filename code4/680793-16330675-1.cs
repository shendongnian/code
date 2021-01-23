    [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetInceDed(int id)
        {
            ClsSalary salary = new ClsSalary();
            var abc  salary=.GetIncDedByEmpId(id);
            string json = "{\"IncDeb\":[\"EmpId\":\"" + abc.EmpId +"\"]"; //And you have to keep going with the other members  
            return json;
    
        }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public JsonResult getData(string name)
            {
                Account account = new Account
                {
                    Email = "james@example.com",
                    Active = true,
                    CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                    Roles = new List<string>
                      {
                        "User",
                        "Admin"
                      }
                };
                return Json(account);
            }

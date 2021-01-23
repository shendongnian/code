    string output = JsonConvert.SerializeObject(list);
    Response.Clear();
    Response.ContentType = "application/json; charset=utf-8";
    Response.Write(output);
    Response.End();

    var response =  JsonConvert.DeserializeObject<Response>(json);
    foreach(var item in response.datas)
    {
        DropDownList1.Items.Add(new ListItem(item.Value, item.Key));
    }
    public class Response
    {
        public bool state;
        public Dictionary<string, string> datas;
    }

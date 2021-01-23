    class M
            {
                public string ExtId { get; set; }
                public string Name { get; set; }
                public List<string> Mobiles { get; set; }
            }
    
    string str = "{\"ExtId\":\"2\",\"Name\":\"VIP\",\"Mobiles\":[\"4533333333\",\"4544444444\"]";
    
    M m = JsonConvert.DeserializeObject<M>(str);

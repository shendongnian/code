     var m_res = JsonConvert.DeserializeObject<YourJsonClass>(YourJsonResponce);        
                foreach (dynamic numb in m_res.result)
                {
    
                    string m_name = numb.Name; // it will be "1", "0" or whatever
                    string h = numb.Value.ToString();
                    var m_value = JsonConvert.DeserializeObject<Item>(h);
                   
                }

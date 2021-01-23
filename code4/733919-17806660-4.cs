          System.Net.WebClient client = new System.Net.WebClient();
          using (var stream = client.OpenRead(url))
          {      
            byte a = 0;
            var list = new List<byte>();
            do{
              a = (byte)stream.ReadByte();
              list.Add(a);
              if(/*Test if valid JSON string*/)
              {
                var str = System.Text.Encoding.UTF8.GetString(list.ToArray());
                JsonConvert.DeserializeObject<MyClass>(str);
              }
            }while(a != -1)
          }

    class Program
    {
        static void Main(string[] args)
        {
            var text = @"[{'Name':'AAA','Age':'22','Job':'PPP'},
                        {'Name':'BBB','Age':'25','Job':'QQQ'},
                        {'Name':'CCC','Age':'38','Job':'RRR'}]";
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(text);
            for (var i = 0; i < data.Count; i++)
            {
                dynamic item = data[i];
                Console.WriteLine("Name: {0}, Age: {1}", (string)item.Name, (string)item.Age);
            }
            Console.ReadLine();
        }
    }

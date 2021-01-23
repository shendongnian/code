    var payload = new[] 
            {
                new{ To = 1, From = 2, Message = "msj1" },
                new{ To = 1, From = 2, Message = "msj2" },
                new{ To = 2, From = 1, Message = "msj3" },
                new{ To = 4, From = 1, Message = "msj4" },
                new{ To = 1, From = 3, Message = "msj5" }
            };
            var groupped = payload.Select(x => new { Key = Math.Min(x.To, x.From) + "_" + Math.Max(x.To, x.From), Envelope = x }).GroupBy(y => y.Key).ToList();
            foreach (var item in groupped)
            {
                Console.WriteLine(String.Format(@"Group: {0}, messages:", item.Key));
                foreach (var element in item)
                {
                    Console.WriteLine(String.Format(@"From: {0} To: {1} Message: {2}", element.Envelope.From, element.Envelope.To, element.Envelope.Message));
                }
            }

            var strings = "0155-0160, 0271-0388, 0455-0503, 0588-687";
            var splitStrings = strings.Split(char.Parse(","));
            var grads = new List<GrandRange>();
            foreach (var item in splitStrings) { 
                var splitAgain = item.Split(char.Parse("-"));
                var grand = new GrandRange
                {
                    Start = int.Parse(splitAgain[0]),
                    Stop = int.Parse(splitAgain[1])
                };
                grads.Add(grand);
            }
        }

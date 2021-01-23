    var node = XElement.Load("LoadFrom");
                    var TheNodeToChange = trayNode.Descendants("displayDateTime").First();
                    var oldDateTime = DateTime.Parse(TheNodeToChange.Value);
                    var newDateTime = oldDateTime;//.DoSomething();
                    TheNodeToChange.Value = newDateTime.ToString();

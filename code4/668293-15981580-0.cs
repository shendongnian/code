     var tmpSection = new Section();
     foreach(var elmList in jsonSection)
            {
                Console.WriteLine("test");
                var element = new StyledStringElement(elmList.ToString())
                {
                    TextColor = UIColor.Red,
                    BackgroundColor = UIColor.Brown,
                    Accessory = UITableViewCellAccessory.DisclosureIndicator
                };
                tmpSection.Elements.Add(element);
            }
            jsonSection.Elements.AddRange(tmpSection); //it this doesn't work, loop through tmpSection and add the elements to jsonSection.

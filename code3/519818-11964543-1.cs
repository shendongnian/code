            string topic = "<option value=\"123\">X</option>\r\n  <option value=\"456\">XX</option>\r\n";
            Console.WriteLine(topic);
            string topicValue = "456";
            string mustBeReplaced = string.Empty;
            string replaceResult = string.Empty;
            if (topic.Contains(topicValue))
            {
                mustBeReplaced = "value=\"" + topicValue + "\"";
                replaceResult = mustBeReplaced + " selected=\"selected\"";
                topic = topic.Replace(mustBeReplaced, replaceResult);
            }
            Console.WriteLine(topic);
            Console.ReadLine();

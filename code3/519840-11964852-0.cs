        var topic = (string)ViewData["TopicID"];
        var mustBeReplaced = string.Empty;
        var topicValue = "11111";
        var replaceResult = string.Empty;
        if (topic.Contains(topicValue))
        {
            mustBeReplaced = "value=\"" + topicValue + "\"";
            replaceResult = mustBeReplaced + " selected=\"selected\"";
            topic = topic.Replace(mustBeReplaced, replaceResult);
        }

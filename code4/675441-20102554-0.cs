    private static void WalkNode(JToken node,
                                    Action<JObject> objectAction = null,
                                    Action<JProperty> propertyAction = null)
    {
        if (node.Type == JTokenType.Object)
        {
            if (objectAction != null) objectAction((JObject) node);
            foreach (JProperty child in node.Children<JProperty>())
            {
                if (propertyAction != null) propertyAction(child);
                WalkNode(child.Value, objectAction, propertyAction);
            }
        }
        else if (node.Type == JTokenType.Array)
        {
            foreach (JToken child in node.Children())
            {
                WalkNode(child, objectAction, propertyAction);
            }
        }
    }

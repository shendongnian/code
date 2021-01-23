    abstract class JsonVisitor
    {
        public virtual JToken Visit(JToken token)
        {
            var clone = token.DeepClone();
            return VisitInternal(clone);
        }
        protected virtual JToken VisitInternal(JToken token)
        {
            switch (token.Type)
            {
            case JTokenType.Object:
                return VisitObject((JObject)token);
            case JTokenType.Property:
                return VisitProperty((JProperty)token);
            case JTokenType.Array:
                return VisitArray((JArray)token);
            case JTokenType.String:
            case JTokenType.Integer:
            case JTokenType.Float:
            case JTokenType.Date:
            case JTokenType.Boolean:
            case JTokenType.Null:
                return VisitValue((JValue)token);
            default:
                throw new InvalidOperationException();
            }
        }
        protected virtual JToken VisitObject(JObject obj)
        {
            foreach (var property in obj.Properties())
                VisitInternal(property);
            return obj;
        }
        protected virtual JToken VisitProperty(JProperty property)
        {
            VisitInternal(property.Value);
            return property;
        }
        protected virtual JToken VisitArray(JArray array)
        {
            foreach (var item in array)
                VisitInternal(item);
            return array;
        }
        protected virtual JToken VisitValue(JValue value)
        {
            return value;
        }
    }

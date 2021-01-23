        public Func<Message, string, bool> FilterData()
        {
            return (message, propName) =>
            {
                var prop = message.GetType().GetProperty(propName);
                if(prop != null){
                    var propValue = (string)prop.GetValue(message,null);
                    return !string.IsNullOrEmpty(propValue) && ...;
                }
                return false;
            };
            
        }

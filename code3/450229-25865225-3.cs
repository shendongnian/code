        public static bool DeserializeJson<T>(this String str, out T item)
        {
            var returnResult = default(T);
            var success = Ui.Instance.Try(
                () =>
                {
                    returnResult = new JavaScriptSerializer().Deserialize<T>(str);
                },
                "Deserializing json " + typeof(T),
                "Deserializing json done",
                "Deserializing json failed",
                isCritical: false
            );
            item = returnResult;
            return success;
        }

        public static void Reusable(HttpRequest httpRequest, string parameter, Label label)
        {
            string title = "";
            switch (httpRequest.QueryString[parameter])
            {
                case "first":
                    title = "123";
                    break;
                case "two":
                    title = "ABC";
                    break;
            }
            label.Text = "My message" + title;
        }

            private void webBrowser1_DocumentCompleted(object sender,WebBrowserDocumentCompletedEventArgs e)
            {
                Ref reff = new Ref();
                //not the same "Ref" as below
            }
            public void load()
            {
                Ref reff = new Ref();
                //not the same "Ref" as above
            }
            //consider using properties instead of members... you get the get/set for free
            public class Ref
            {
                public string URL { get; set; }
                public void Load()
                {
                    //do your load set
                    this.URL = "What you want";
                }
                //...
            }
            //you can also declare the constructor on the fly if you want.. or call the Load() method
            Ref myRef = new Ref()
            {
                URL = "What you want"
            };

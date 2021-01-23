    using (JSObject myGlobalObject = webControl1.CreateGlobalJavascriptObject("myGlobalObject"))
            {
                // The handler is of type JavascriptMethodEventHandler. Here we define it
                // using a lambda expression.
                myGlobalObject.Bind("myMethod", true, (s, ee) =>
                {
                    // Provide a response.
                    ee.Result = "My response";
                });
            }
